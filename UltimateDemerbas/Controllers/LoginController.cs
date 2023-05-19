using Functions;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using UltimateAPI.Entities;
using UltimateDemerbas.Manager;
using UltimateDemerbas.Models.Mailer;
using UltimateDemerbas.Models.Tool;
using System.Collections.Generic;
using System.Text.Json;

namespace UltimateDemerbas.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private IConfiguration Configuration;
        CompanyManager company;
        UserManager user;
        CodeManager code;
        public LoginController(IHttpClientFactory httpClientFactory, IConfiguration _configuration)
        {
            _httpClientFactory = httpClientFactory;
            company = new CompanyManager(_httpClientFactory);
            user = new UserManager(_httpClientFactory);
            code = new CodeManager(_httpClientFactory);
            Configuration = _configuration;
        }

        [CheckAuthorize]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCompanyV1([FromBody] CompanyUser parameter)
        {
            var result = company.AddCompanyV1(parameter);
            return Content(result.Result);
        }

        [HttpPost]
        public IActionResult IsValidateCode([FromBody] Code parameter)
        {
            var result = code.IsValidateCode(parameter);
            return Content(result.Result);
        }

        private void isUnicInfo(User parameter, ref UltimateSetResult unicResult)
        {
            var responseUser = user.GetAllUser();
            List<User> users = JsonSerializer.Deserialize<UltimateResult<List<User>>>(responseUser.Result).Data;
            if (users != null)
            {
                bool isHaveEmail = users.Find(x => x.MailAdress == parameter.MailAdress) == null;
                bool isHaveUsername = users.Find(x => x.UserName == parameter.UserName) == null;

                if (!isHaveEmail)
                {
                    unicResult.Message = "Bu email adresi zaten kullanılmaktadır. Farklı bir email adresi deneyiniz.";
                    unicResult.IsSuccess = false;
                }
                else if (!isHaveUsername)
                {
                    unicResult.Message = "Bu username zaten kullanılmaktadır. Farklı bir username deneyiniz.";
                    unicResult.IsSuccess = false;
                }
            }

            var responseCompany = company.GetCompanies();
            List<Company> companyList = JsonSerializer.Deserialize<UltimateResult<List<Company>>>(responseCompany.Result).Data;
            if (company != null)
            {
                bool isHaveCompanyname = companyList.Find(x => x.Name == parameter.Company) == null;
                if (!isHaveCompanyname)
                {
                    unicResult.Message = "Farklı bir companyname deneyiniz. Bu companyname zaten kullanılmaktadır.";
                    unicResult.IsSuccess = false;
                }
            }
        }

        [HttpPost]
        public IActionResult SetEmailValidation([FromBody] User parameter, [FromQuery] string sessionId)
        {
            UltimateSetResult result = new UltimateSetResult();
            Mailer mailler = new Mailer(Configuration);
            Mail mail = new Mail();

            UltimateSetResult unicResult = new UltimateSetResult();
            isUnicInfo(parameter, ref unicResult);
            if (!unicResult.IsSuccess)
            {
                return Content(ResultData.Get(unicResult.IsSuccess, unicResult.Message, null));
            }



            string newCode = CodeCreator.CreateCode(10);

            mail.To = parameter.MailAdress;
            mail.Body = $"Code required to create a new company: <b>[{newCode}]</b> UFS.com";
            mail.Subject = "Reset Password in Ultimate Fixture";

            var sendResult = mailler.Sendmail(mail);
            if (sendResult)
            {
                CodeManager codeManager = new CodeManager(_httpClientFactory);
                Code code = new Code();
                code.UserRefId = 0;
                code.CodeString = newCode;
                code.SessionId = sessionId;

                codeManager.AddCode(code);
            }
            else
            {
                result.IsSuccess = false;
                result.Message = "Beklenmedik bir hata oluştu.";
            }

            return Content(ResultData.Get(result.IsSuccess, result.Message, null));
        }

    }
}
