using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using UltimateAPI.Entities;
using UltimateDemerbas.Manager;
using UltimateDemerbas.Models.Tool;

namespace UltimateDemerbas.Controllers
{
    [CheckAuthorize]
    public class FixtureModelController : BaseController
    {
        protected override int PageNumber { get; set; } = 0;
        private readonly IHttpClientFactory _httpClientFactory;
        FixtureModelManager fixtureModel;
        public FixtureModelController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            fixtureModel = new FixtureModelManager(_httpClientFactory);
        }


        [CheckAuthorize]
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult GetFixtureModels()
        {
            var result = fixtureModel.GetFixtureModels();

            return Content(result.Result);
        }

        public IActionResult DeleteFixtureModel([FromBody] FixtureModel parameter)
        {
            parameter.UserId = WorkingUser;
            var result = fixtureModel.DeleteFixtureModel(parameter);
            return Content(result.Result);
        }

        public IActionResult AddFixtureModel([FromBody] FixtureModel data)
        {
            data.UserId = WorkingUser;
            var result = fixtureModel.AddFixtureModel(data);
            return Content(result.Result);
        }

        public IActionResult UpdateFixtureModel([FromBody] FixtureModel data)
        {
            data.UserId = WorkingUser;
            var result = fixtureModel.UpdateFixtureModel(data);
            return Content(result.Result);
        }

    }
}
