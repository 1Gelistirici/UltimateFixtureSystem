using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using UltimateDemerbas.Manager;
using UltimateDemerbas.Models.Tool;

namespace UltimateDemerbas.Controllers
{
    [CheckAuthorize]
    public class MenuController : BaseController
    {
        protected override int PageNumber { get; set; } = 0;
        private readonly IHttpClientFactory _httpClientFactory;
        MenuManager menu;
        public MenuController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            menu = new MenuManager(_httpClientFactory);
        }


        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult GetMenuCompany()
        //{
        //    FixLic parameter = new FixLic();
        //    parameter.CompanyId = WorkingCompany;
        //    var result = fixture.GetFixLices(parameter);

        //    return Content(result.Result);
        //}


    }
}
