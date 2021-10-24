using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using UltimateDemerbas.Entities;
using UltimateDemerbas.Manager;

namespace UltimateDemerbas.Controllers
{
    public class ComponentModelController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ComponentModelController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult GetComponentModels()
        {
            ComponentModelManager componentModel = new ComponentModelManager(_httpClientFactory);
            var result = componentModel.GetComponentModels();

            return Content(result.Result);
        }

        public IActionResult DeleteComponentModel([FromBody] ComponentModel parameter)
        {
            parameter.UserId = Convert.ToInt32(Request.Cookies["id"]);

            ComponentModelManager componentModel = new ComponentModelManager(_httpClientFactory);
            var result = componentModel.DeleteComponentModel(parameter);

            return Content(result.Result);
        }

        public IActionResult AddComponentModel([FromBody] ComponentModel data)
        {
            data.UserId = Convert.ToInt32(Request.Cookies["id"]);

            ComponentModelManager componentModel = new ComponentModelManager(_httpClientFactory);
            var result = componentModel.AddComponentModel(data);

            return Content(result.Result);
        }

        public IActionResult UpdateComponentModel([FromBody] ComponentModel data)
        {
            data.UserId = Convert.ToInt32(Request.Cookies["id"]);

            ComponentModelManager componentModel = new ComponentModelManager(_httpClientFactory);
            var result = componentModel.UpdateComponentModel(data);

            return Content(result.Result);
        }

    }
}
