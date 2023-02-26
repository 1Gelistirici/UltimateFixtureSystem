using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using UltimateAPI.Entities;
using UltimateDemerbas.Manager;
using UltimateDemerbas.Models.Tool;

namespace UltimateDemerbas.Controllers
{
    [CheckAuthorize]
    public class MenuController : BaseController
    {
        protected override int PageNumber { get; set; } = 23;
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

        public IActionResult GetMenu()
        {
            var result = menu.GetMenu();
            return Content(result.Result);
        }

        public IActionResult UpdateMenu([FromBody] Menu parameter)
        {
            var result = menu.UpdateMenu(parameter);
            return Content(result.Result);
        }

        public IActionResult AddMenu([FromBody] Menu parameter)
        {
            var result = menu.AddMenu(parameter);
            return Content(result.Result);
        }

        public IActionResult DeleteMenu([FromBody] Menu parameter)
        {
            var result = menu.DeleteMenu(parameter);
            return Content(result.Result);
        }

    }
}
