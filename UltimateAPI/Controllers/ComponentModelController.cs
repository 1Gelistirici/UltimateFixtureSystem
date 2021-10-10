using Microsoft.AspNetCore.Mvc;
using UltimateAPI.CallManager;
using UltimateAPI.Entities;

namespace UltimateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComponentModelController : ControllerBase
    {
        [HttpPost("AddComponentModel")]
        public IActionResult AddComponentModel(ComponentModel parameter)
        {
            ComponentModelCallManager componentModel = new ComponentModelCallManager();
            var result = componentModel.AddComponentModel(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpGet("GetComponentModels")]
        public IActionResult GetComponentModels()
        {
            ComponentModelCallManager componentModel = new ComponentModelCallManager();
            var result = componentModel.GetComponentModels();
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("DeleteComponentModel")]
        public IActionResult DeleteComponentModel(ComponentModel parameter)
        {
            ComponentModelCallManager componentModel = new ComponentModelCallManager();
            var result = componentModel.DeleteComponentModel(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("UpdateComponentModel")]
        public IActionResult UpdateComponenModel(ComponentModel parameter)
        {
            ComponentModelCallManager componentModel = new ComponentModelCallManager();
            var result = componentModel.UpdateComponenModel(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }
    }
}
