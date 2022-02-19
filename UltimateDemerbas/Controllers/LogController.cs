using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using UltimateAPI.Entities;
using UltimateDemerbas.Manager;
using UltimateDemerbas.Models.Tool;

namespace UltimateDemerbas.Controllers
{
    [CheckAuthorize]
    public class LogController : BaseController
    {
        protected override int PageNumber { get; set; } = 0;
        private readonly IHttpClientFactory _httpClientFactory;
        LogManager log;
        public LogController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            log = new LogManager(_httpClientFactory);
        }

        [CheckAuthorize]
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult GetLogs()
        {
            Log parameter = new Log();
            parameter.UserId = WorkingUser;

            var result = log.GetLogs(parameter);
            return Content(result.Result);
        }

        public IActionResult DeleteLog([FromBody] Log parameter)
        {
            var result = log.DeleteLog(parameter);
            return Content(result.Result);
        }

        public IActionResult AddLog([FromBody] Log parameter)
        {
            var result = log.AddLog(parameter);
            return Content(result.Result);
        }
    }
}
