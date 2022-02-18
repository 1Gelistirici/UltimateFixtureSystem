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

        [HttpPost("GetUserCompany")]
        public IActionResult GetUserCompany(User parameter)
        {
            var result = UserCallManager.Instance.GetUserCompany(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }
        
        [HttpPost("GetUsers")]
        public IActionResult GetUsers(User parameter)
        {
            var result = UserCallManager.Instance.GetUsers(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("ChangePassword")]
        public IActionResult ChangePassword(User parameter)
        {
            var result = UserCallManager.Instance.ChangePassword(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }
        [HttpPost("UpdateProfile")]
        public IActionResult UpdateProfile(User parameter)
        {
            var result = UserCallManager.Instance.UpdateProfile(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }




    }
}
