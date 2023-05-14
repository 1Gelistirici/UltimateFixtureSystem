using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using UltimateAPI.CallManager;
using UltimateAPI.Entities;

namespace UltimateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemHistoryController : ControllerBase
    {
        [HttpPost("AddItemHistory")]
        public IActionResult AddItemHistory(ItemHistory parameter)
        {
            UltimateSetResult result = ItemHistoryCallManager.Instance.AddItemHistory(parameter);
            return Content(UltimateSetResult.Get(result.IsSuccess, result.Message, result.ReturnId));
        }

        [HttpPost("GetItemHistoryByCompany")]
        public IActionResult GetItemHistoryByCompany(ReferansParameter parameter)
        {
            UltimateResult<List<ItemHistory>> result = ItemHistoryCallManager.Instance.GetItemHistoryByCompany(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

    }
}
