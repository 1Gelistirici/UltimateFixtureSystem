using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using UltimateAPI.Entities;
using UltimateAPI.Entities.Enums;
using UltimateDemerbas.Manager;
using UltimateDemerbas.Models.Tool;

namespace UltimateDemerbas.Controllers
{
    [CheckAuthorize]
    public class ReportController : BaseController
    {
        protected override int PageNumber { get; set; } = 43;
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
        public IActionResult ReportedAssets()
        {
            return View();
        }

        [CheckAuthorize]
        public IActionResult ReportHistory()
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

        public IActionResult GetReportedAssetsByCompany()
        {
            var result = report.GetReportedAssetsByCompany(new ReferansParameter() { RefId = WorkingCompany });
            return Content(result.Result);
        }

        public IActionResult GetReportsByUserRefId()
        {
            var result = report.GetReportsByUserRefId(new ReferansParameter() { RefId = WorkingUser });
            return Content(result.Result);
        }

        public IActionResult GetReportsByStatu([FromBody] ReportStatu reportStatu)
        {
            var result = report.GetReportsByStatu(reportStatu);
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
