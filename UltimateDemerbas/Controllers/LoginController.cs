using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using UltimateAPI.Entities;
using UltimateDemerbas.Manager;

namespace UltimateDemerbas.Controllers
{
    public class LoginController : BaseController
    {
        protected override int PageNumber { get; set; } = 0;
        private readonly IHttpClientFactory _httpClientFactory;
        LoginManager login;
        public LoginController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            login = new LoginManager(_httpClientFactory);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Authenticate([FromBody] User user)
        {
            user.UserId = WorkingUser;
            var result = login.Authenticate(user);
            return Content(result.Result);
        }
    }
}
