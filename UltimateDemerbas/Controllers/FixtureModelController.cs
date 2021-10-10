using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using UltimateDemerbas.Entities;
using UltimateDemerbas.Manager;

namespace UltimateDemerbas.Controllers
{
    public class FixtureModelController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public FixtureModelController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult GetFixtureModels()
        {
            FixtureModelManager fixtureModel = new FixtureModelManager(_httpClientFactory);
            var result = fixtureModel.GetFixtureModels();

            return Content(result.Result);
        }

        public IActionResult DeleteFixtureModel([FromBody] FixtureModel parameter)
        {
            parameter.UserId = Convert.ToInt32(Request.Cookies["id"]);

            FixtureModelManager fixtureModel = new FixtureModelManager(_httpClientFactory);
            var result = fixtureModel.DeleteFixtureModel(parameter);

            return Content(result.Result);
        }

        public IActionResult AddFixtureModel([FromBody] FixtureModel data)
        {
            data.UserId = Convert.ToInt32(Request.Cookies["id"]);

            FixtureModelManager fixtureModel = new FixtureModelManager(_httpClientFactory);
            var result = fixtureModel.AddFixtureModel(data);

            return Content(result.Result);
        }

        public IActionResult UpdateFixtureModel([FromBody] FixtureModel data)
        {
            data.UserId = Convert.ToInt32(Request.Cookies["id"]);

            FixtureModelManager fixtureModel = new FixtureModelManager(_httpClientFactory);
            var result = fixtureModel.UpdateFixtureModel(data);

            return Content(result.Result);
        }

    }
}
