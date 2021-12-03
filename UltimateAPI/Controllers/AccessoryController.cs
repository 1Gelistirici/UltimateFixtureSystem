using Microsoft.AspNetCore.Mvc;
using UltimateAPI.CallManager;
using UltimateAPI.Entities;

namespace UltimateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessoryController : ControllerBase
    {
        [HttpPost("AddAccessory")]
        public IActionResult AddAccessory(Accessory parameter)
        {
            AccessoryCallManager accessory = new AccessoryCallManager();
            var result = accessory.AddAccessory(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpGet("GetAccessories")]
        public IActionResult GetAccessories()
        {
            AccessoryCallManager accessory = new AccessoryCallManager();
            var result = accessory.GetAccessories();
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }
        
        [HttpPost("GetAccessory")]
        public IActionResult GetAccessory(Accessory parameter)
        {
            AccessoryCallManager accessory = new AccessoryCallManager();
            var result = accessory.GetAccessory(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("DeleteAccessory")]
        public IActionResult DeleteAccessory(Accessory parameter)
        {
            AccessoryCallManager accessory = new AccessoryCallManager();
            var result = accessory.DeleteAccessory(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("UpdateAccessory")]
        public IActionResult UpdateAccessory(Accessory parameter)
        {
            AccessoryCallManager accessory = new AccessoryCallManager();
            var result = accessory.UpdateAccessory(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }
    }
}
