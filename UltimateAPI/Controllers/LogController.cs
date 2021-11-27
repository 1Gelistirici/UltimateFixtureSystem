using Microsoft.AspNetCore.Mvc;
using UltimateAPI.CallManager;
using UltimateAPI.Entities;

namespace UltimateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        [HttpPost("AddLog")]
        public IActionResult AddLog(Log parameter)
        {
            LogCallManager log = new LogCallManager();
            var result = log.AddLog(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("GetLogs")]
        public IActionResult GetLogs(Log parameter)
        {
            LogCallManager log = new LogCallManager();
            var result = log.GetLogs(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("DeleteLog")]
        public IActionResult DeleteLog(Log parameter)
        {
            LogCallManager log = new LogCallManager();
            var result = log.DeleteLog(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

    }
}
