using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using UltimateDemerbas.Manager;
using UltimateDemerbas.Models.Tool;

namespace UltimateDemerbas.Controllers
{
    [CheckAuthorize]
    public class LayoutController : BaseController
    {
        protected override int PageNumber { get; set; } = 0;
        private readonly IHttpClientFactory _httpClientFactory;
        LayoutManager layoutManager;
        public LayoutController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            layoutManager = new LayoutManager(_httpClientFactory);
        }

        [CheckAuthorize]
        public IActionResult Index()
        {
            return View();
        }

        [CheckAuthorize]
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
