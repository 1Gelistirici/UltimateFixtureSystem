using Microsoft.AspNetCore.Mvc;
using UltimateAPI.Entities;
using UltimateAPI.Manager;

namespace UltimateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelevantPersonnelController : ControllerBase
    {
        [HttpPost("AddRelevantPersonnel")]
        public IActionResult AddRelevantPersonnel(RelevantPersonnel parameter)
        {
            var result = RelevantPersonnelManager.Instance.AddRelevantPersonnel(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("GetRelevantPersonnels")]
        public IActionResult GetRelevantPersonnels(ReferansParameter parameter)
        {
            var result = RelevantPersonnelManager.Instance.GetRelevantPersonnels(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("DeleteRelevantPersonnel")]
        public IActionResult DeleteRelevantPersonnel(ReferansParameter parameter)
        {
            var result = RelevantPersonnelManager.Instance.DeleteRelevantPersonnel(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }
    }
}
