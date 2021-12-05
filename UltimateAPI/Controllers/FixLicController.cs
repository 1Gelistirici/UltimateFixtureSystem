using Microsoft.AspNetCore.Mvc;
using UltimateAPI.CallManager;
using UltimateAPI.Entities;

namespace UltimateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FixLicController : ControllerBase
    {
        [HttpPost("AddFixLic")]
        public IActionResult AddFixLic(FixLic parameter)
        {
            var result = FixLitCallManager.Instance.AddFixLic(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("GetFixLices")]
        public IActionResult GetFixLices(FixLic parameter)
        {
            var result = FixLitCallManager.Instance.GetFixLices(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }






    }
}
