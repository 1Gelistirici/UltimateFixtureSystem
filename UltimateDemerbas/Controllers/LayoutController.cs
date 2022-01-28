using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using UltimateDemerbas.Manager;

namespace UltimateDemerbas.Controllers
{
    public class LayoutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        LayoutManager layoutManager;
        public LayoutController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            layoutManager = new LayoutManager(_httpClientFactory);
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
            var result = layoutManager.GetMenus();

            return Content(result.Result);
        }
    }
}
