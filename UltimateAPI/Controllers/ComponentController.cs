using Microsoft.AspNetCore.Mvc;
using UltimateAPI.CallManager;
using UltimateAPI.Entities;

namespace UltimateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComponentController : ControllerBase
    {
        [HttpPost("AddComponent")]
        public IActionResult AddComponent(Component parameter)
        {
            ComponentCallManager component = new ComponentCallManager();
            var result = component.AddComponent(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("GetComponentByCompanyRefId")]
        public IActionResult GetComponentByCompanyRefId(ReferansParameter parameter)
        {
            ComponentCallManager component = new ComponentCallManager();
            var result = component.GetComponentByCompanyRefId(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpGet("GetComponents")]
        public IActionResult GetComponents()
        {
            ComponentCallManager component = new ComponentCallManager();
            var result = component.GetComponents();
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("DeleteComponent")]
        public IActionResult DeleteComponent(Component parameter)
        {
            ComponentCallManager component = new ComponentCallManager();
            var result = component.DeleteComponent(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("UpdateComponent")]
        public IActionResult UpdateComponent(Component parameter)
        {
            ComponentCallManager component = new ComponentCallManager();
            var result = component.UpdateComponent(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }
    }
}
