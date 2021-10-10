using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using UltimateDemerbas.Entities;
using UltimateDemerbas.Manager;

namespace UltimateDemerbas.Controllers
{
    public class LogController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public LogController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult GetLogs()
        {
            Log parameter = new Log();
            parameter.UserId = Convert.ToInt32(Request.Cookies["id"]);

            LogManager log = new LogManager(_httpClientFactory);
            var result = log.GetLogs(parameter);

            return Content(result.Result);
        }

        public IActionResult DeleteLog([FromBody] Log parameter)
        {
            LogManager log = new LogManager(_httpClientFactory);
            var result = log.DeleteLog(parameter);

            return Content(result.Result);
        }

        public IActionResult AddLog([FromBody] Log parameter)
        {
            LogManager log = new LogManager(_httpClientFactory);
            var result = log.AddLog(parameter);

            return Content(result.Result);
        }

     
    }
}
