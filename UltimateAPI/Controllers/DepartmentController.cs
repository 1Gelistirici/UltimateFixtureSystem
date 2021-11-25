using Microsoft.AspNetCore.Mvc;
using UltimateAPI.CallManager;
using UltimateAPI.Entities;

namespace UltimateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        [HttpGet("GetDepartments")]
        public IActionResult GetDepartments(Department parameter)
        {
            var result = DepartmentCallManager.Instance.GetDepartments(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }



    }
}
