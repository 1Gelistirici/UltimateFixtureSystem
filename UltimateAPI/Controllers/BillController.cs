using Microsoft.AspNetCore.Mvc;
using UltimateAPI.CallManager;
using UltimateAPI.Entities;

namespace UltimateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        [HttpPost("AddBill")]
        public IActionResult AddBill(Bill parameter)
        {

            BillCallManager bill = new BillCallManager();
            var result = bill.AddBill(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpGet("GetBills")]
        public IActionResult GetBills()
        {
            BillCallManager bill = new BillCallManager();
            var result = bill.GetBills();
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("DeleteBill")]
        public IActionResult DeleteBill(Bill parameter)
        {
            BillCallManager bill = new BillCallManager();
            var result = bill.DeleteBill(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("UpdateBill")]
        public IActionResult UpdateBill(Bill parameter)
        {
            BillCallManager bill = new BillCallManager();
            var result = bill.UpdateBill(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("DeleteBillItem")]
        public IActionResult DeleteBillItem(BillItem parameter)
        {
            BillCallManager bill = new BillCallManager();
            var result = bill.DeleteBillItem(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

    }
}
