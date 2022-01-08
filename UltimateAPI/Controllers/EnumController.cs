using Microsoft.AspNetCore.Mvc;
using UltimateAPI.CallManager;
using UltimateAPI.Entities;

namespace UltimateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnumController : ControllerBase
    {
        [HttpGet("GetIsActiveTypes")]
        public ActionResult GetIsActiveTypes()
        {
            var result = EnumCallManager.Instance.GetIsActiveTypes();
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpGet("GetItemStatuTypes")]
        public ActionResult GetItemStatuTypes()
        {
            var result = EnumCallManager.Instance.GetItemStatuTypes();
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpGet("GetItemTypeTypes")]
        public ActionResult GetItemTypeTypes()
        {
            var result = EnumCallManager.Instance.GetItemTypeTypes();
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

    }
}
