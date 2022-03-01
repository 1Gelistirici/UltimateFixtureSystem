using Microsoft.AspNetCore.Mvc;
using UltimateAPI.CallManager;
using UltimateAPI.Entities;

namespace UltimateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        [HttpPost("GetMenuRoleCompany")]
        public IActionResult GetUserRoleCompany(UserRole parameter)
        {
            var result = UserRoleCallManager.Instance.GetUserRoleCompany(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }
    }
}
