using Microsoft.AspNetCore.Mvc;
using UltimateAPI.CallManager;
using UltimateAPI.Entities;

namespace UltimateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        [HttpPost("AddReport")]
        public IActionResult AddReport(Report parameter)
        {
            var result = ReportCallManager.Instance.AddReport(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpGet("GetReports")]
        public IActionResult GetReports()
        {
            var result = ReportCallManager.Instance.GetReports();
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }
    }
}
