using Microsoft.AspNetCore.Mvc;
using UltimateAPI.CallManager;
using UltimateAPI.Entities;

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
