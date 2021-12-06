using Microsoft.AspNetCore.Mvc;
using UltimateAPI.CallManager;
using UltimateAPI.Entities;

namespace UltimateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        [HttpPost("AddMessage")]
        public IActionResult AddMessage(Message parameter)
        {
            var result = MessageCallManager.Instance.AddMessage(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("GetMessages")]
        public IActionResult GetMessages(Message parameter)
        {
            var result = MessageCallManager.Instance.GetMessages(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("DeleteMessage")]
        public IActionResult DeleteMessage(Message parameter)
        {
            var result = MessageCallManager.Instance.DeleteMessage(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

    }
}
