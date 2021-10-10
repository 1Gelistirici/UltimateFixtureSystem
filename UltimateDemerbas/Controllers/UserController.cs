using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using UltimateDemerbas.Entities;
using UltimateDemerbas.Manager;

namespace UltimateDemerbas.Controllers
{
    public class UserController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public UserController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
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
            UserManager user = new UserManager(_httpClientFactory);
            var result = user.CheckUser(parameter);
            
            return Content(result.Result);
        }
        
        public IActionResult GetUser()
        {
            User parameter = new User();
            parameter.UserId = Convert.ToInt32(Request.Cookies["id"]);

            UserManager user = new UserManager(_httpClientFactory);
            var result = user.GetUser(parameter);
            
            return Content(result.Result);
        }
        
        public IActionResult ChangePassword([FromBody] User parameter)
        {
            parameter.UserId = Convert.ToInt32(Request.Cookies["id"]);

            UserManager user = new UserManager(_httpClientFactory);
            var result = user.ChangePassword(parameter);
            
            return Content(result.Result);
        }

    }
}
