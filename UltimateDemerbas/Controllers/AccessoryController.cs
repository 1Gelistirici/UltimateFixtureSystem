using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using UltimateAPI.Entities;
using UltimateDemerbas.Manager;

namespace UltimateDemerbas.Controllers
{
    public class AccessoryController : Controller
    {
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
            parameter.UserId = Convert.ToInt32(Request.Cookies["id"]);
            var result = accessory.GetAccessory(parameter);

            return Content(result.Result);
        }

        public IActionResult DeleteAccessory([FromBody] Accessory parameter)
        {
            parameter.UserId = Convert.ToInt32(Request.Cookies["id"]);
            var result = accessory.DeleteAccessory(parameter);
            return Content(result.Result);
        }

        public IActionResult AddAccessory([FromBody] Accessory parameter)
        {
            parameter.UserId = Convert.ToInt32(Request.Cookies["id"]);
            var result = accessory.AddAccessory(parameter);
            return Content(result.Result);
        }

        public IActionResult UpdateAccessory([FromBody] Accessory parameter)
        {
            parameter.UserId = Convert.ToInt32(Request.Cookies["id"]);
            var result = accessory.UpdateAccessory(parameter);
            return Content(result.Result);
        }
    }
}
