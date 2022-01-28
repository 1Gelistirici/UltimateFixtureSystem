using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using UltimateAPI.Entities;
using UltimateDemerbas.Manager;

namespace UltimateDemerbas.Controllers
{
    public class ComponentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        ComponentManager component;
        public ComponentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            component = new ComponentManager(_httpClientFactory);
        }


        public IActionResult Index()
        {
            return View();
        }


        public IActionResult GetComponents()
        {
            var result = component.GetComponents();
            return Content(result.Result);
        }

        public IActionResult DeleteComponent([FromBody] Component parameter)
        {
            parameter.UserId = Convert.ToInt32(Request.Cookies["id"]);
            var result = component.DeleteComponent(parameter);
            return Content(result.Result);
        }

        public IActionResult AddComponent([FromBody] Component parameter)
        {
            parameter.UserId = Convert.ToInt32(Request.Cookies["id"]);
            var result = component.AddComponent(parameter);
            return Content(result.Result);
        }

        public IActionResult UpdateComponent([FromBody] Component parameter)
        {
            parameter.UserId = Convert.ToInt32(Request.Cookies["id"]);
            var result = component.UpdateComponent(parameter);
            return Content(result.Result);
        }
    }
}
