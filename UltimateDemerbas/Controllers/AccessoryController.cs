using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using UltimateAPI.Entities;
using UltimateDemerbas.Manager;
using UltimateDemerbas.Models.Tool;

namespace UltimateDemerbas.Controllers
{
    [CheckAuthorize]
    public class AccessoryController : BaseController
    {
        protected override int PageNumber { get; set; } = 28;
        private readonly IHttpClientFactory _httpClientFactory;
        AccessoryManager accessory;
        public AccessoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            accessory = new AccessoryManager(_httpClientFactory);
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Assignments()
        {
            return View();
        }

        public IActionResult GetAccessories()
        {
            var result = accessory.GetAccessories();
            return Content(result.Result);
        }

        public IActionResult GetAccessory()
        {
            Accessory parameter = new Accessory();
            parameter.UserId = WorkingUser;
            var result = accessory.GetAccessory(parameter);

            return Content(result.Result);
        }

        public IActionResult DeleteAccessory([FromBody] Accessory parameter)
        {
            parameter.UserId = WorkingUser;
            var result = accessory.DeleteAccessory(parameter);
            return Content(result.Result);
        }

        public IActionResult AddAccessory([FromBody] Accessory parameter)
        {
            parameter.UserId = WorkingUser;
            var result = accessory.AddAccessory(parameter);
            return Content(result.Result);
        }

        public IActionResult UpdateAccessory([FromBody] Accessory parameter)
        {
            parameter.UserId = WorkingUser;
            var result = accessory.UpdateAccessory(parameter);
            return Content(result.Result);
        }
    }
}
