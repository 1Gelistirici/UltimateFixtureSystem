using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using UltimateAPI.Entities;
using UltimateDemerbas.Manager;

namespace UltimateDemerbas.Controllers
{
    public class SituationController : BaseController
    {
        protected override int PageNumber { get; set; } = 0;
        private readonly IHttpClientFactory _httpClientFactory;
        SituationManager situation;
        public SituationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            situation = new SituationManager(_httpClientFactory);
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult GetSituations()
        {
            var result = situation.GetSituations();

            return Content(result.Result);
        }

        public IActionResult DeleteSituation([FromBody] Situation parameter)
        {
            parameter.UserId = WorkingUser;

            var result = situation.DeleteSituation(parameter);

            return Content(result.Result);
        }

        public IActionResult UpdateSituation([FromBody] Situation data)
        {
            data.UserId = WorkingUser;

            var result = situation.UpdateSituation(data);

            return Content(result.Result);
        }

        public IActionResult AddSituation([FromBody] Situation data)
        {
            data.UserId = WorkingUser;

            var result = situation.AddSituation(data);

            return Content(result.Result);
        }
    }
}
