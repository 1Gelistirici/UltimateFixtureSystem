using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using UltimateAPI.Entities;
using UltimateDemerbas.Manager;
using UltimateDemerbas.Models.Tool;

namespace UltimateDemerbas.Controllers
{
    public class ComponentModelController : BaseController
    {
        protected override int PageNumber { get; set; } = 1;
        private readonly IHttpClientFactory _httpClientFactory;
        ComponentModelManager componentModel;
        public ComponentModelController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            componentModel = new ComponentModelManager(_httpClientFactory);
        }


        [CheckAuthorize]
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult GetComponentModels()
        {
            var result = componentModel.GetComponentModels();
            return Content(result.Result);
        }

        public IActionResult DeleteComponentModel([FromBody] ComponentModel parameter)
        {
            parameter.UserId = WorkingUser;
            var result = componentModel.DeleteComponentModel(parameter);
            return Content(result.Result);
        }

        public IActionResult AddComponentModel([FromBody] ComponentModel data)
        {
            data.UserId = WorkingUser;
            var result = componentModel.AddComponentModel(data);
            return Content(result.Result);
        }

        public IActionResult UpdateComponentModel([FromBody] ComponentModel data)
        {
            data.UserId = WorkingUser;
            var result = componentModel.UpdateComponentModel(data);
            return Content(result.Result);
        }

    }
}
