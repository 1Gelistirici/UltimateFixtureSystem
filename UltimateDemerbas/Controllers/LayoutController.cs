using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using UltimateDemerbas.Manager;

namespace UltimateDemerbas.Controllers
{
    public class LayoutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public LayoutController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Tester()
        {
            return View();
        }

        public IActionResult GetMenus()
        {
            LayoutManager layoutManager = new LayoutManager(_httpClientFactory);
            var result = layoutManager.GetMenus();

            return Content(result.Result);
        }













    }
}
