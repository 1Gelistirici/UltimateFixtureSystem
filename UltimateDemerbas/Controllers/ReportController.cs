using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using UltimateAPI.Entities;
using UltimateDemerbas.Manager;

namespace UltimateDemerbas.Controllers
{
    public class ReportController : BaseController
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ReportController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetReports()
        {
            ReportManager report = new ReportManager(_httpClientFactory);
            var result = report.GetReports();

            return Content(result.Result);
        }

        public IActionResult AddReport([FromBody] Report parameter)
        {
            parameter.UserId = WorkingUser;

            ReportManager report = new ReportManager(_httpClientFactory);
            var result = report.AddReport(parameter);

            return Content(result.Result);
        }
    }
}
