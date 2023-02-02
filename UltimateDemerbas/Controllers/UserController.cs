using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using System.Net.Http;
using UltimateAPI.Entities;
using UltimateDemerbas.Manager;
using UltimateDemerbas.Models.Mailer;
using UltimateDemerbas.Models.Tool;
using Functions;
using System;
using UltimateAPI.Entities.Enums;
using System.IO;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace UltimateDemerbas.Controllers
{
    public class UserController : BaseController
    {
        protected override int PageNumber { get; set; } = 0;
        private readonly IHttpClientFactory _httpClientFactory;
        private IConfiguration Configuration;
        UserManager user;

        public UserController(IHttpClientFactory httpClientFactory, IConfiguration _configuration)
        {
            _httpClientFactory = httpClientFactory;
            user = new UserManager(_httpClientFactory);
            Configuration = _configuration;
        }

        [CheckAuthorize]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            if (WorkingUser > 0)
            {
                Response.Redirect("/Home/Index");
            }

            return View();
        }

        [CheckAuthorize]
        public IActionResult ChangePassword([FromBody] User parameter)
        {
            if (parameter.Password != parameter.PasswordTry)
            {
                return Content("Şifreler Uyuşmuyor");
            }

            parameter.UserId = WorkingUser;
            var result = user.ChangePassword(parameter);


            return Content(result.Result);
        }

        public IActionResult CheckUser([FromBody] User parameter)
        {
            var result = user.CheckUser(parameter);

            UltimateResult<User> resultUser = JsonSerializer.Deserialize<UltimateResult<User>>(result.Result);

            if (resultUser.IsSuccess)
            {
                ReferansParameter referansParameter = new ReferansParameter();
                referansParameter.Id = Convert.ToInt32(resultUser.Data.Id);
                referansParameter.CompanyId = Convert.ToInt32(resultUser.Data.CompanyId);
                SetSession(referansParameter);
            }

            if (parameter.RememberMe && resultUser.IsSuccess)
            {
                CookieOptions cookie = new CookieOptions();
                cookie.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Append("companyId", resultUser.Data.CompanyId.ToString(), cookie);
                Response.Cookies.Append("userId", resultUser.Data.Id.ToString(), cookie);
            }


            return Content(result.Result);
        }

        public IActionResult ForgetPassword([FromBody] User parameter)
        {
            UltimateResult<User> result = new UltimateResult<User>();

            try
            {
                var response = user.GetUserCompanyUserName(parameter);
                User userData = JsonSerializer.Deserialize<UltimateResult<User>>(response.Result).Data;

                result.IsSuccess = true;
                result.Message = "Eğer girilen bilgiler doğru ise mail gönderilmiştir.";

                if (userData != null)
                {
                    string newCode = CodeCreator.CreateCode(10);


                    Mailer mailler = new Mailer(Configuration);
                    Mail mail = new Mail();

                    mail.To = userData.MailAdress;
                    mail.Body = $"Use this key for reset Password: <b>[{newCode}]</b> The code is valid for 5 minutes only.";
                    mail.Subject = "Reset Password in Ultimate Fixture";

                    var sendResult = mailler.Sendmail(mail);
                    if (sendResult)
                    {
                        CodeManager codeManager = new CodeManager(_httpClientFactory);
                        Code code = new Code();
                        code.UserRefId = userData.Id;
                        code.CodeString = newCode;

                        codeManager.AddCode(code);
                    }
                    else
                    {
                        result.IsSuccess = false;
                        result.Message = "Beklenmedik bir hata oluştu.";
                        return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
                    }
                }

                return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
            }
            catch (System.Exception)
            {
                result.IsSuccess = true;
                result.Message = "Eğer girilen bilgiler doğru ise mail gönderilmiştir.";
                return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
            }
        }

        public IActionResult ForgetPasswordChange([FromBody] Code parameter)
        {
            if (parameter.Password != parameter.TryPassword)
            {
                return Content(ResultData.Get(false, "Şifreler uyuşmuyor.", null));
            }

            CodeManager codeManager = new CodeManager(_httpClientFactory);
            var response = codeManager.GetCode(new Code { CodeString = parameter.CodeString });
            Code codeData = JsonSerializer.Deserialize<UltimateResult<Code>>(response.Result).Data;

            if (codeData == null)
            {
                return Content(ResultData.Get(false, "Kod aktif değil.", null));
            }

            User userInfo = new User();
            userInfo.UserId = codeData.UserRefId;
            userInfo.Password = parameter.Password;
            userInfo.OldPassword = parameter.TryPassword;
            var result = user.ForgetChangePassword(userInfo);

            return Content(result.Result);
        }

        [CheckAuthorize]
        public IActionResult GetUser()
        {
            User parameter = new User();
            parameter.UserId = WorkingUser;
            var result = user.GetUser(parameter);
            return Content(result.Result);
        }

        [CheckAuthorize]
        public IActionResult GetUserCompany()
        {
            FileHelper fileHelper = new FileHelper(Configuration);
            string folder = fileHelper.GetSaveURL(SaveFile.User, WorkingCompany);

            User parameter = new User();
            parameter.CompanyId = WorkingCompany;
            var response = user.GetUserCompany(parameter);

            UltimateResult<List<User>> result = JsonSerializer.Deserialize<UltimateResult<List<User>>>(response.Result);
            foreach (var item in result.Data)
            {
                if (item.ImageName != "")
                {
                    item.ImageUrl = Path.Combine(folder, item.ImageName);
                }
                else
                {
                    item.ImageUrl = "";
                }
            }

            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [CheckAuthorize]
        public IActionResult GetUsers()
        {
            User parameter = new User();
            parameter.CompanyId = WorkingCompany;
            var result = user.GetUsers(parameter);
            return Content(result.Result);
        }

        [CheckAuthorize]
        public IActionResult AddUser()
        {
            string folderUrl = "";
            FileHelper fileHelper = new FileHelper(Configuration);

            try
            {
                User parameter = JsonHelper.JsonConvert<User>(Request.Form["parameter"]);
                parameter.CompanyId = WorkingCompany;
                parameter.ImageName = "";
                parameter.ImageUrl = "";

                if (Request.Form.Files.Count > 0)
                {
                    var file = Request.Form.Files[0];
                    string folder = fileHelper.GetSaveURL(SaveFile.User, WorkingCompany);

                    string fileGuId = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    folderUrl = Path.Combine(folder, fileGuId);

                    if (file != null)
                    {
                        UltimateResult<User> result = new UltimateResult<User>();
                        parameter.ImageName = fileGuId;
                        parameter.ImageUrl = folderUrl;

                        var response = user.AddUser(parameter).Result;
                        result = JsonSerializer.Deserialize<UltimateResult<User>>(response);

                        if (result.IsSuccess)
                        {
                            using (FileStream fs = System.IO.File.Create(folderUrl))
                            {
                                file.CopyTo(fs);
                            }
                        }

                        return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
                    }
                }
                else
                {
                    var response = user.AddUser(parameter).Result;
                    UltimateResult<User> result = JsonSerializer.Deserialize<UltimateResult<User>>(response);
                    return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
                }
            }
            catch (Exception ex)
            {
                System.IO.File.Delete(folderUrl);
            }

            return Content("");
        }

        [CheckAuthorize]
        [HttpPost]
        public IActionResult UpdateUser()
        {
            string folderUrl = "";

            try
            {
                FileHelper fileHelper = new FileHelper(Configuration);

                User parameter = JsonHelper.JsonConvert<User>(Request.Form["parameter"]);

                if (Request.Form.Files.Count > 0)
                {
                    var file = Request.Form.Files[0];
                    string folder = fileHelper.GetSaveURL(SaveFile.User, WorkingCompany);

                    string fileGuId = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    folderUrl = Path.Combine(folder, fileGuId);

                    if (file != null)
                    {
                        System.IO.File.Delete(parameter.ImageUrl);

                        UltimateResult<User> result = new UltimateResult<User>();
                        parameter.ImageName = fileGuId;
                        parameter.ImageUrl = folderUrl;
                        parameter.CompanyId = WorkingCompany;

                        var response = user.UpdateUser(parameter).Result;
                        result = JsonSerializer.Deserialize<UltimateResult<User>>(response);

                        if (result.IsSuccess)
                        {
                            using (FileStream fs = System.IO.File.Create(folderUrl))
                            {
                                file.CopyTo(fs);
                            }
                        }

                        return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
                    }
                }
                else
                {
                    var result = user.UpdateUser(parameter);
                    return Content(result.Result);
                }
            }
            catch (Exception ex)
            {
                if (folderUrl != "")
                {
                    System.IO.File.Delete(folderUrl);
                }
            }

            return Content("");
        }

        [CheckAuthorize]
        public IActionResult DeleteUser([FromBody] User parameter)
        {
            var result = user.DeleteUser(parameter);
            return Content(result.Result);
        }

        [CheckAuthorize]
        public IActionResult UpdateProfile([FromBody] User parameter)
        {
            parameter.UserId = WorkingUser;
            var result = user.UpdateProfile(parameter);
            return Content(result.Result);
        }

        //[CheckAuthorize]
        //public IActionResult CheckAddUser([FromBody] User parameter)
        //{
        //    UltimateResult<User> result = new UltimateResult<User>();


        //    if (parameter.PasswordTry != parameter.Password)
        //    {
        //        result.Message = "Şifreler uyuşmuyor.";
        //        result.IsSuccess = false;
        //    }


        //    User user = new User();
        //    user.CompanyId = WorkingCompany;
        //    var a = user.GetUserCompany();


        //}


        //Login Session
        public IActionResult SetUserSession([FromBody] ReferansParameter parameter)
        {
            SetSession(parameter);
            return Ok();
        }

        //Exit Session
        public IActionResult RemoveActiveUserSession()
        {
            RemoveActiveUser();
            return null;
        }
    }
}
