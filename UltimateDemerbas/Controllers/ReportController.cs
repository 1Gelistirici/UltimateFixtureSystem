using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using UltimateAPI.Entities;
using UltimateDemerbas.Manager;

namespace UltimateDemerbas.Controllers
{
    public class ReportController : BaseController
    {
        private readonly IHttpClientFactory _httpClientFactory;
        ReportManager report;
        public ReportController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            report = new ReportManager(_httpClientFactory);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PassiveReports()
        {
            return View();
        }

        public IActionResult GetReports()
        {
            var result = report.GetReports();
            return Content(result.Result);
        }

        public IActionResult GetPassiveReports()
        {
            var result = report.GetPassiveReports();
            return Content(result.Result);
        }

        public IActionResult AddReport([FromBody] Report parameter)
        {
            parameter.UserId = WorkingUser;

            var result = report.AddReport(parameter);
            return Content(result.Result);
        }

        public IActionResult UpdateReportStatu([FromBody] Report parameter)
        {
            parameter.UserId = WorkingUser;

            var result = report.UpdateReportStatu(parameter);
            return Content(result.Result);
        }
    }
}
