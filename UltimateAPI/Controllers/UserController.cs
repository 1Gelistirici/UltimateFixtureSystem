using Microsoft.AspNetCore.Mvc;
using UltimateAPI.CallManager;
using UltimateAPI.Entities;

namespace UltimateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpPost("CheckUser")]
        public IActionResult CheckUser(User parameter)
        {
            var result = UserCallManager.Instance.CheckUser(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("GetUser")]
        public IActionResult GetUser(User parameter)
        {
            var result = UserCallManager.Instance.GetUser(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("ChangePassword")]
        public IActionResult ChangePassword(User parameter)
        {
            var result = UserCallManager.Instance.ChangePassword(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }




    }
}
