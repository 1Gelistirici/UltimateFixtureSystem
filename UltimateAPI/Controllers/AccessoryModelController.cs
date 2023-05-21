using Microsoft.AspNetCore.Mvc;
using UltimateAPI.CallManager;
using UltimateAPI.Entities;

namespace UltimateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessoryModelController : ControllerBase
    {
        [HttpPost("AddAccessoryModel")]
        public IActionResult AddAccessoryModel(AccessoryModel parameter)
        {
            AccessoryModelCallManager accessoryModel = new AccessoryModelCallManager();
            var result = accessoryModel.AddAccessoryModel(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpGet("GetAccessoryModels")]
        public IActionResult GetAccessoryModels()
        {
            AccessoryModelCallManager accessoryModel = new AccessoryModelCallManager();
            var result = accessoryModel.GetAccessoryModels();
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("GetAccessoryModelByCompanyRefId")]
        public IActionResult GetAccessoryModelByCompanyRefId(ReferansParameter parameter)
        {
            AccessoryModelCallManager accessoryModel = new AccessoryModelCallManager();
            var result = accessoryModel.GetAccessoryModelByCompanyRefId(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("DeleteAccessoryModel")]
        public IActionResult DeleteAccessoryModel(AccessoryModel parameter)
        {
            AccessoryModelCallManager accessoryModel = new AccessoryModelCallManager();
            var result = accessoryModel.DeleteAccessoryModel(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("UpdateAccessoryModel")]
        public IActionResult UpdateAccessoryModel(AccessoryModel parameter)
        {
            AccessoryModelCallManager accessoryModel = new AccessoryModelCallManager();
            var result = accessoryModel.UpdateAccessoryModel(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }
    }
}
