using Microsoft.AspNetCore.Mvc;
using UltimateAPI.CallManager;
using UltimateAPI.Entities;

namespace UltimateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillTypeController : ControllerBase
    {
        [HttpPost("AddBillType")]
        public IActionResult AddBillType(BillType parameter)
        {
            BillTypeCallManager billType = new BillTypeCallManager();
            var result = billType.AddBillType(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpGet("GetBillTypes")]
        public IActionResult GetBillTypes()
        {
            BillTypeCallManager billType = new BillTypeCallManager();
            var result = billType.GetBillTypes();
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("DeleteBillType")]
        public IActionResult DeleteBillType(BillType parameter)
        {
            BillTypeCallManager billType = new BillTypeCallManager();
            var result = billType.DeleteBillType(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("GetBillTypeByCompanyRefId")]
        public IActionResult GetBillTypeByCompanyRefId(ReferansParameter parameter)
        {
            BillTypeCallManager billType = new BillTypeCallManager();
            var result = billType.GetBillTypeByCompanyRefId(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("UpdateBillType")]
        public IActionResult UpdateBillType(BillType parameter)
        {
            BillTypeCallManager billType = new BillTypeCallManager();
            var result = billType.UpdateBillType(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }
    }
}
