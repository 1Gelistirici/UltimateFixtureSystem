using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using System.Net.Http;
using UltimateAPI.Entities;
using UltimateDemerbas.Manager;
using UltimateDemerbas.Models.Mailer;
using UltimateDemerbas.Models.Tool;
using Functions;

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
            return Content(result.Result);
        }

        public IActionResult ForgetPassword([FromBody] User parameter)
        {

            var response = user.GetUserCompanyUserName(parameter);
            User userData = JsonSerializer.Deserialize<UltimateResult<User>>(response.Result).Data;


            if (userData.Id > 0)
            {
                string newCode = CodeCreator.CreateCode(10);


                Mailer mailler = new Mailer(Configuration);
                Mail mail = new Mail();

                mail.To = userData.MailAdress;
                mail.Body = $"Use this key for reset Password: <b>{newCode}</b> The code is valid for 5 minutes only.";
                mail.Subject = "Reset Password in Ultimate Fixture";

                var sendResult = mailler.Sendmail(mail);
                if (sendResult)
                {

                }
            }




            return Content("");














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
            User parameter = new User();
            parameter.CompanyId = WorkingCompany;
            var result = user.GetUserCompany(parameter);
            return Content(result.Result);
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
        public IActionResult AddUser([FromBody] User parameter)
        {
            if (parameter.Password != parameter.PasswordTry)
            {
                return Content("Şifreler Uyuşmuyor");
            }

            parameter.CompanyId = WorkingCompany;
            var result = user.AddUser(parameter);
            return Content(result.Result);
        }

        [CheckAuthorize]
        [HttpPost]
        public IActionResult UpdateUser([FromBody] User parameter)
        {
            var result = user.UpdateUser(parameter);
            return Content(result.Result);
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
