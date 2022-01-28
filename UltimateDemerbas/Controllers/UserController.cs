using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using UltimateAPI.Entities;
using UltimateDemerbas.Manager;

namespace UltimateDemerbas.Controllers
{
    public class UserController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        UserManager user;

        public UserController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            user = new UserManager(_httpClientFactory);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }


        public IActionResult CheckUser([FromBody] User parameter)
        {
            var result = user.CheckUser(parameter);

            return Content(result.Result);
        }
        public IActionResult GetUser()
        {
            User parameter = new User();
            parameter.UserId = Convert.ToInt32(Request.Cookies["id"]);

            var result = user.GetUser(parameter);

            return Content(result.Result);
        }
        public IActionResult GetUsers()
        {
            User parameter = new User();
            parameter.CompanyId = 1; // ToDo : WorkingCompany Bakılacak

            var result = user.GetUsers(parameter);

            return Content(result.Result);
        }
        public IActionResult UpdateProfile([FromBody] User parameter)
        {
            parameter.UserId = Convert.ToInt32(Request.Cookies["id"]);

            var result = user.UpdateProfile(parameter);

            return Content(result.Result);
        }
        public IActionResult ChangePassword([FromBody] User parameter)
        {
            if (parameter.Password != parameter.PasswordTry)
            {
                return Content("Şifreler Uyuşmuyor");
            }

            parameter.UserId = Convert.ToInt32(Request.Cookies["id"]);

            var result = user.ChangePassword(parameter);

            return Content(result.Result);
        }

    }
}
