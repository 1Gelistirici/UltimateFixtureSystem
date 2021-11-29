using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using UltimateAPI.Entities;
using UltimateDemerbas.Manager;

namespace UltimateDemerbas.Controllers
{
    public class SituationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public SituationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult GetSituations()
        {
            SituationManager situation = new SituationManager(_httpClientFactory);
            var result = situation.GetSituations();

            return Content(result.Result);
        }

        public IActionResult DeleteSituation([FromBody] Situation parameter)
        {
            parameter.UserId = Convert.ToInt32(Request.Cookies["id"]);
        
            SituationManager situation = new SituationManager(_httpClientFactory);
            var result = situation.DeleteSituation(parameter);

            return Content(result.Result);
        }

        public IActionResult UpdateSituation([FromBody] Situation data)
        {
            data.UserId = Convert.ToInt32(Request.Cookies["id"]);

            SituationManager situation = new SituationManager(_httpClientFactory);
            var result = situation.UpdateSituation(data);

            return Content(result.Result);
        }

        public IActionResult AddSituation([FromBody] Situation data)
        {
            data.UserId = Convert.ToInt32(Request.Cookies["id"]);

            SituationManager situation = new SituationManager(_httpClientFactory);
            var result = situation.AddSituation(data);

            return Content(result.Result);
        }
    }
}
