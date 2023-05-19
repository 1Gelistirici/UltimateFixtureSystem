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

        [HttpPost("DeleteCodeBySessionId")]
        public IActionResult DeleteCodeBySessionId(string sessionId)
        {
            var result = CodeCallManager.Instance.DeleteCodeBySessionId(sessionId);
            return Content(UltimateSetResult.Get(result.IsSuccess, result.Message, result.ReturnId));
        }

        [HttpPost("GetCode")]
        public IActionResult GetCode(Code parameter)
        {
            var result = CodeCallManager.Instance.GetCode(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("GetCodeV1")]
        public IActionResult GetCodeV1(Code parameter)
        {
            var result = CodeCallManager.Instance.GetCodeV1(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("IsValidateCode")]
        public IActionResult IsValidateCode(Code parameter)
        {
            var result = CodeCallManager.Instance.IsValidateCode(parameter);
            return Content(UltimateSetResult.Get(result.IsSuccess, result.Message, result.ReturnId));
        }

    }
}
