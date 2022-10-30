using Microsoft.AspNetCore.Mvc;
using UltimateAPI.CallManager;
using UltimateAPI.Entities;

namespace UltimateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        //[HttpPost("GetMenuCompany")]
        //public IActionResult GetMenuCompany(Menu parameter)
        //{
        //    var result = MenuCallManager.Instance.GetMenuCompany(parameter);
        //    return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        //}

    }
}
