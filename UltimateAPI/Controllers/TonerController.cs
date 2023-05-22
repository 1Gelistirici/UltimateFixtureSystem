using Microsoft.AspNetCore.Mvc;
using UltimateAPI.CallManager;
using UltimateAPI.Entities;

namespace UltimateAPI.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class TonerController : ControllerBase
    {
        [HttpPost("AddToner")]
        public IActionResult AddToner(Toner parameter)
        {
            TonerCallManager toner = new TonerCallManager();
            var result = toner.AddToner(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpGet("GetToners")]
        public IActionResult GetToners()
        {
            TonerCallManager toner = new TonerCallManager();
            var result = toner.GetToners();
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("DeleteToner")]
        public IActionResult DeleteToner(Toner parameter)
        {
            TonerCallManager toner = new TonerCallManager();
            var result = toner.DeleteToner(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("UpdateToner")]
        public IActionResult UpdateToner(Toner parameter)
        {
            TonerCallManager toner = new TonerCallManager();
            var result = toner.UpdateToner(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("GetTonerByCompanyRefId")]
        public IActionResult GetTonerByCompanyRefId(ReferansParameter parameter)
        {
            TonerCallManager toner = new TonerCallManager();
            var result = toner.GetTonerByCompanyRefId(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }


        //[HttpGet("GetToners")]
        //public IActionResult GetToners()
        //{
        //    TonerCallManager toners = new TonerCallManager();
        //    var result = toners.GetToners();
        //    return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        //}

        //[HttpPost("GetToner")]
        //public IActionResult GetToner(Toner toner)
        //{
        //    TonerCallManager toners = new TonerCallManager();
        //    var result = toners.GetToner(toner);
        //    return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        //}

    }
}
