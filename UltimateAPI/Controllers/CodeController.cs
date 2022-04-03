using Microsoft.AspNetCore.Mvc;
using UltimateAPI.CallManager;
using UltimateAPI.Entities;

namespace UltimateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodeController : ControllerBase
    {
        [HttpPost("AddCode")]
        public IActionResult AddCode(Code parameter)
        {
            var result = CodeCallManager.Instance.AddCode(parameter);
            return Content(ResultData.Get(result, "", ""));
        }

        [HttpPost("GetCode")]
        public IActionResult GetCode(Code parameter)
        {
            var result = CodeCallManager.Instance.GetCode(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }
    }
}
