using Microsoft.AspNetCore.Mvc;
using UltimateAPI.CallManager;
using UltimateAPI.Entities;

namespace UltimateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        [HttpPost("GetRole")]
        public IActionResult GetRole(UserRole parameter)
        {
            var result = UserRoleCallManager.Instance.GetRole(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("AddRole")]
        public IActionResult AddRole(UserRole parameter)
        {
            var result = UserRoleCallManager.Instance.AddRole(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("DeleteRole")]
        public IActionResult DeleteRole(UserRole parameter)
        {
            var result = UserRoleCallManager.Instance.DeleteRole(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }
    }
}
