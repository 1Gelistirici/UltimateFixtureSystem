using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using UltimateAPI.Entities;
using UltimateDemerbas.Manager;

namespace UltimateDemerbas.Controllers
{
    public class TonerController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public TonerController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult GetToners()
        {
            TonerManager toner = new TonerManager(_httpClientFactory);
            var result = toner.GetToners();

            return Content(result.Result);
        }

        public IActionResult DeleteToner([FromBody] Toner parameter)
        {
            parameter.UserId = Convert.ToInt32(Request.Cookies["id"]);

            TonerManager toner = new TonerManager(_httpClientFactory);
            var result = toner.DeleteToner(parameter);

            return Content(result.Result);
        }

        public IActionResult AddToner([FromBody] Toner parameter)
        {
            parameter.UserId = Convert.ToInt32(Request.Cookies["id"]);

            TonerManager toner = new TonerManager(_httpClientFactory);
            var result = toner.AddToner(parameter);

            return Content(result.Result);
        }

        public IActionResult UpdateToner([FromBody] Toner parameter)
        {
            parameter.UserId = Convert.ToInt32(Request.Cookies["id"]);

            TonerManager toner = new TonerManager(_httpClientFactory);
            var result = toner.UpdateToner(parameter);

            return Content(result.Result);
        }


        //public IActionResult GetToner([FromBody] Login login)
        //{
        //    TonerManager tonerManager = new TonerManager(_httpClientFactory);
        //    var result = tonerManager.GetToner(login);

        //    return Content(result.Result);
        //}

        //public IActionResult GetToners()
        //{
        //    TonerManager tonerManager = new TonerManager(_httpClientFactory);
        //    var result = tonerManager.GetToners();

        //    return Content(result.Result);
        //}

    }
}
