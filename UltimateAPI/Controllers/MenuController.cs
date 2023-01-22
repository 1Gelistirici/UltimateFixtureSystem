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

        [HttpPost("AddMenu")]
        public IActionResult AddMenu(Menu parameter)
        {
            var result = MenuCallManager.Instance.AddMenu(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("UpdateMenu")]
        public IActionResult UpdateMenu(Menu parameter)
        {
            var result = MenuCallManager.Instance.UpdateMenu(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("DeleteMenu")]
        public IActionResult DeleteMenu(Menu parameter)
        {
            var result = MenuCallManager.Instance.DeleteMenu(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }


    }
}
