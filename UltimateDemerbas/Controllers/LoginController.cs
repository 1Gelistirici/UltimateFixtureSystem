using Functions;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using UltimateAPI.Entities;
using UltimateDemerbas.Manager;
using UltimateDemerbas.Models.Tool;

namespace UltimateDemerbas.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        CompanyManager company;
        UserManager user;
        public LoginController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            company = new CompanyManager(_httpClientFactory);
            user = new UserManager(_httpClientFactory);
        }

        [CheckAuthorize]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddCompany([FromBody] Company parameter)
        {
            var result = company.AddCompany(parameter);
            return Content(result.Result);
        }



        public IActionResult AddUser()
        {
            User parameter = JsonHelper.JsonConvert<User>(Request.Form["parameter"]);

            var result = user.UpdateUser(parameter);
            return Content(result.Result);
        }



    }
}
