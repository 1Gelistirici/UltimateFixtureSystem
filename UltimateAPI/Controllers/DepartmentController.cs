using Microsoft.AspNetCore.Mvc;
using UltimateAPI.CallManager;
using UltimateAPI.Entities;

namespace UltimateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        [HttpPost("GetDepartments")]
        public IActionResult GetDepartments(Department parameter)
        {
            var result = DepartmentCallManager.Instance.GetDepartments(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("GetDepartmentByCompanyRefId")]
        public IActionResult GetDepartmentByCompanyRefId(ReferansParameter parameter)
        {
            var result = DepartmentCallManager.Instance.GetDepartmentByCompanyRefId(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("AddDepartment")]
        public IActionResult AddDepartment(Department parameter)
        {
            var result = DepartmentCallManager.Instance.AddDepartment(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("DeleteDepartment")]
        public IActionResult DeleteDepartment(Department parameter)
        {
            var result = DepartmentCallManager.Instance.DeleteDepartment(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("UpdateDepartment")]
        public IActionResult UpdateDepartment(Department parameter)
        {
            var result = DepartmentCallManager.Instance.UpdateDepartment(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }
    }
}
