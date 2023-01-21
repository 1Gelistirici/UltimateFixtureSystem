using Microsoft.AspNetCore.Mvc;
using UltimateAPI.CallManager;
using UltimateAPI.Entities;

namespace UltimateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        [HttpGet("GetMenu")]
        public IActionResult GetMenu()
        {
            var result = MenuCallManager.Instance.GetMenu();
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

    }
}
