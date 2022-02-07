using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using UltimateAPI.Entities;
using UltimateDemerbas.Manager;

namespace UltimateDemerbas.Controllers
{
    public class TonerController : BaseController
    {
        protected override int PageNumber { get; set; } = 0;
        private readonly IHttpClientFactory _httpClientFactory;
        TonerManager toner;
        public TonerController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            toner = new TonerManager(_httpClientFactory);
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult GetToners()
        {
            var result = toner.GetToners();

            return Content(result.Result);
        }

        public IActionResult DeleteToner([FromBody] Toner parameter)
        {
            parameter.UserId = Convert.ToInt32(Request.Cookies["id"]);

            var result = toner.DeleteToner(parameter);

            return Content(result.Result);
        }

        public IActionResult AddToner([FromBody] Toner parameter)
        {
            parameter.UserId = Convert.ToInt32(Request.Cookies["id"]);

            var result = toner.AddToner(parameter);

            return Content(result.Result);
        }

        public IActionResult UpdateToner([FromBody] Toner parameter)
        {
            parameter.UserId = Convert.ToInt32(Request.Cookies["id"]);

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
