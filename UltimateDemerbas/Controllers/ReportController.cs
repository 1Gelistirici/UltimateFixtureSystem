using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using UltimateAPI.Entities;
using UltimateDemerbas.Manager;
using UltimateDemerbas.Models.Tool;

namespace UltimateDemerbas.Controllers
{
    [CheckAuthorize]
    public class ReportController : BaseController
    {
        protected override int PageNumber { get; set; } = 0;
        private readonly IHttpClientFactory _httpClientFactory;
        ReportManager report;
        public ReportController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            report = new ReportManager(_httpClientFactory);
        }

        [CheckAuthorize]
        public IActionResult Index()
        {
            return View();
        }

        [CheckAuthorize]
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
