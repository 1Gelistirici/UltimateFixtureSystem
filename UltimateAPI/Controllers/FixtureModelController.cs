using Microsoft.AspNetCore.Mvc;
using UltimateAPI.CallManager;
using UltimateAPI.Entities;

namespace UltimateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FixtureModelController : ControllerBase
    {
        [HttpPost("AddFixtureModel")]
        public IActionResult AddFixtureModel(FixtureModel parameter)
        {
            FixtureModelCallManager fixtureModel = new FixtureModelCallManager();
            var result = fixtureModel.AddFixtureModel(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("GetFixtureModelByCompanyRefId")]
        public IActionResult GetFixtureModelByCompanyRefId(ReferansParameter parameter)
        {
            FixtureModelCallManager fixtureModel = new FixtureModelCallManager();
            var result = fixtureModel.GetFixtureModelByCompanyRefId(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpGet("GetFixtureModels")]
        public IActionResult GetFixtureModels()
        {
            FixtureModelCallManager fixtureModel = new FixtureModelCallManager();
            var result = fixtureModel.GetFixtureModels();
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("DeleteFixtureModel")]
        public IActionResult DeleteFixtureModel(FixtureModel parameter)
        {
            FixtureModelCallManager fixtureModel = new FixtureModelCallManager();
            var result = fixtureModel.DeleteFixtureModel(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("UpdateFixtureModel")]
        public IActionResult UpdateFixtureModel(FixtureModel parameter)
        {
            FixtureModelCallManager fixtureModel = new FixtureModelCallManager();
            var result = fixtureModel.UpdateFixtureModel(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }
    }
}
