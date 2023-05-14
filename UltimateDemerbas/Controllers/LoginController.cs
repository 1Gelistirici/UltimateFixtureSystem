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

        [HttpPost]
        public IActionResult AddCompanyV1([FromBody] CompanyUser parameter)
        {
            var result = company.AddCompanyV1(parameter);
            return Content(result.Result);
        }

    }
}
