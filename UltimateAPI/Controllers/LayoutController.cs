using Microsoft.AspNetCore.Mvc;
using UltimateAPI.CallManager;
using UltimateAPI.Entities;

namespace UltimateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class layoutController : ControllerBase
    {

        //[Authorize]
        [HttpGet("GetMenus")]
        public IActionResult GetToners()
        {
            LayoutCallManager layouts= new LayoutCallManager();
            var result = layouts.GetMenus();
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }
















    }
}
