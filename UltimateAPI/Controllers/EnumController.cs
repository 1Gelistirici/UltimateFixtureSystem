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
        
        [HttpGet("GetReportStatus")]
        public ActionResult GetReportStatus()
        {
            var result = EnumCallManager.Instance.GetReportStatus();
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }
        
        [HttpGet("GetProductTypes")]
        public ActionResult GetProductTypes()
        {
            var result = EnumCallManager.Instance.GetProductTypes();
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }
        
        [HttpGet("GetDepartments")]
        public ActionResult GetDepartments()
        {
            var result = EnumCallManager.Instance.GetDepartments();
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }
        
        [HttpGet("GetGenders")]
        public ActionResult GetGenders()
        {
            var result = EnumCallManager.Instance.GetGenders();
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }
        
        [HttpGet("GetImportanceLevels")]
        public ActionResult GetImportanceLevels()
        {
            var result = EnumCallManager.Instance.GetImportanceLevels();
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }
    }
}
