using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
            UltimateResult<List<Accessory>> result = accessory.AddAccessory(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpGet("GetAccessories")]
        public IActionResult GetAccessories()
        {
            AccessoryCallManager accessory = new AccessoryCallManager();
            UltimateResult<List<Accessory>> result = accessory.GetAccessories();
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("GetAccessory")]
        public IActionResult GetAccessory(Accessory parameter)
        {
            AccessoryCallManager accessory = new AccessoryCallManager();
            UltimateResult<Accessory> result = accessory.GetAccessory(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("GetAccessoryByUser")]
        public IActionResult GetAccessoryByUser(Accessory parameter)
        {
            AccessoryCallManager accessory = new AccessoryCallManager();
            UltimateResult<List<Accessory>> result = accessory.GetAccessoryByUser(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }
        

        [HttpPost("GetAccessoryByCompanyRefId")]
        public IActionResult GetAccessoryByCompanyRefId(ReferansParameter parameter)
        {
            AccessoryCallManager accessory = new AccessoryCallManager();
            UltimateResult<List<Accessory>> result = accessory.GetAccessoryByCompanyRefId(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("DeleteAccessory")]
        public IActionResult DeleteAccessory(Accessory parameter)
        {
            AccessoryCallManager accessory = new AccessoryCallManager();
            UltimateResult<List<Accessory>> result = accessory.DeleteAccessory(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("UpdateAccessory")]
        public IActionResult UpdateAccessory(Accessory parameter)
        {
            AccessoryCallManager accessory = new AccessoryCallManager();
            UltimateResult<List<Accessory>> result = accessory.UpdateAccessory(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }
    }
}
