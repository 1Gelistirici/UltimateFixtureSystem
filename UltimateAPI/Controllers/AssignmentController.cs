using Microsoft.AspNetCore.Mvc;
using UltimateAPI.CallManager;
using UltimateAPI.Entities;

namespace UltimateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        [HttpPost("AddAssignment")]
        public IActionResult AddAssignment(Assignment parameter)
        {
            AssignmentCallManager assignment = new AssignmentCallManager();
            var result = assignment.AddAssignment(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("GetAssignments")]
        public IActionResult GetAssignments(Assignment parameter)
        {
            AssignmentCallManager assignment = new AssignmentCallManager();
            var result = assignment.GetAssignments(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("GetAssignmentsByCompany")]
        public IActionResult GetAssignmentsByCompany(Assignment parameter)
        {
            AssignmentCallManager assignment = new AssignmentCallManager();
            var result = assignment.GetAssignmentsByCompany(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }
    
        [HttpPost("DeleteAssignment")]
        public IActionResult DeleteAssignment(Assignment parameter)
        {
            AssignmentCallManager assignment = new AssignmentCallManager();
            var result = assignment.DeleteAssignment(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("UpdateAssignment")]
        public IActionResult UpdateAssignment(Assignment parameter)
        {
            AssignmentCallManager assignment = new AssignmentCallManager();
            var result = assignment.UpdateAssignment(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("GetAssignmentUser")]
        public IActionResult GetAssignmentUser(Assignment parameter)
        {
            AssignmentCallManager assignment = new AssignmentCallManager();
            var result = assignment.GetAssignmentUser(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }
    }
}
