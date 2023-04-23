using Microsoft.AspNetCore.Mvc;
using UltimateAPI.CallManager;
using UltimateAPI.Entities;
using UltimateAPI.Entities.Enums;

namespace UltimateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        [HttpGet("GetReports")]
        public IActionResult GetReports()
        {
            var result = ReportCallManager.Instance.GetReports();
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("GetReportsByStatu")]
        public IActionResult GetReportsByStatu(ReportStatu reportStatu)
        {
            var result = ReportCallManager.Instance.GetReportsByStatu(reportStatu);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("GetReportedAssetsByCompany")]
        public IActionResult GetReportedAssetsByCompany(ReferansParameter parameter)
        {
            var result = ReportCallManager.Instance.GetReportedAssetsByCompany(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpGet("GetPassiveReports")]
        public IActionResult GetPassiveReports()
        {
            var result = ReportCallManager.Instance.GetPassiveReports();
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }
        
        [HttpPost("AddReport")]
        public IActionResult AddReport(Report parameter)
        {
            var result = ReportCallManager.Instance.AddReport(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("UpdateReportStatu")]
        public IActionResult UpdateReportStatu(Report parameter)
        {
            var result = ReportCallManager.Instance.UpdateReportStatu(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }
    }
}
