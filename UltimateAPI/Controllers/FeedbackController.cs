using Microsoft.AspNetCore.Mvc;
using UltimateAPI.CallManager;
using UltimateAPI.Entities;

namespace UltimateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        [HttpPost("AddFeedback")]
        public IActionResult AddFeedback(Feedback parameter)
        {
            var result = FeedbackCallManager.Instance.AddFeedback(parameter);
            return Content(UltimateSetResult.Get(result.IsSuccess, result.Message, result.ReturnId));
        }

        [HttpPost("GetFeedbackByUser")]
        public IActionResult GetFeedbackByUser(ReferansParameter parameter)
        {
            var result = FeedbackCallManager.Instance.GetFeedbackByUser(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.ReturnId));
        }

    }
}
