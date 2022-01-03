using Microsoft.AspNetCore.Mvc;
using UltimateAPI.CallManager;
using UltimateAPI.Entities;

namespace UltimateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsedTonerController : ControllerBase
    {
        [HttpGet("GetUsedToners")]
        public IActionResult GetUsedToners()
        {
            var result = UsedTonerCallManager.Instance.GetUsedToners();
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("GetUsedToner")]
        public IActionResult GetUsedToner(UsedToner parameter)
        {
            var result = UsedTonerCallManager.Instance.GetUsedToner(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("AddUsedToner")]
        public IActionResult AddUsedToner(UsedToner parameter)
        {
            var result = UsedTonerCallManager.Instance.AddUsedToner(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("DeleteUsedToner")]
        public IActionResult DeleteUsedToner(UsedToner parameter)
        {
            var result = UsedTonerCallManager.Instance.DeleteUsedToner(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("UpdateUsedToner")]
        public IActionResult UpdateUsedToner(UsedToner parameter)
        {
            var result = UsedTonerCallManager.Instance.UpdateUsedToner(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }
    }
}
