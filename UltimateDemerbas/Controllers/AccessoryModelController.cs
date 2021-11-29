using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using UltimateAPI.Entities;
using UltimateDemerbas.Manager;

namespace UltimateDemerbas.Controllers
{
    public class AccessoryModelController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AccessoryModelController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult GetAccessoryModels()
        {
            AccessoryModelManager accessoryModel = new AccessoryModelManager(_httpClientFactory);
            var result = accessoryModel.GetAccessoryModels();

            return Content(result.Result);
        }

        public IActionResult DeleteAccessoryModel([FromBody] AccessoryModel parameter)
        {
            parameter.UserId = Convert.ToInt32(Request.Cookies["id"]);

            AccessoryModelManager accessoryModel = new AccessoryModelManager(_httpClientFactory);
            var result = accessoryModel.DeleteAccessoryModel(parameter);

            return Content(result.Result);
        }

        public IActionResult AddAccessoryModel([FromBody] AccessoryModel parameter)
        {
            parameter.UserId = Convert.ToInt32(Request.Cookies["id"]);

            AccessoryModelManager accessoryModel = new AccessoryModelManager(_httpClientFactory);
            var result = accessoryModel.AddAccessoryModel(parameter);

            return Content(result.Result);
        }

        public IActionResult UpdateAccessoryModel([FromBody] AccessoryModel parameter)
        {
            parameter.UserId = Convert.ToInt32(Request.Cookies["id"]);

            AccessoryModelManager accessoryModel = new AccessoryModelManager(_httpClientFactory);
            var result = accessoryModel.UpdateAccessoryModel(parameter);

            return Content(result.Result);
        }
    }
}
