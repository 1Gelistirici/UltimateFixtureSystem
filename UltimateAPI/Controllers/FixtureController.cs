using Microsoft.AspNetCore.Mvc;
using UltimateAPI.CallManager;
using UltimateAPI.Entities;

namespace UltimateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FixtureController : ControllerBase
    {
        [HttpGet("GetFixtures")]
        public IActionResult GetFixtures()
        {
            FixtureCallManager fixture = new FixtureCallManager();
            var result = fixture.GetFixtures();
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("GetFixture")]
        public IActionResult GetFixture(Fixture parameter)
        {
            FixtureCallManager fixture = new FixtureCallManager();
            var result = fixture.GetFixture(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("GetFixtureByUser")]
        public IActionResult GetFixtureByUser(Fixture parameter)
        {
            FixtureCallManager fixture = new FixtureCallManager();
            var result = fixture.GetFixtureByUser(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }
        
        [HttpPost("AddFixture")]
        public IActionResult AddFixture(Fixture parameter)
        {
            FixtureCallManager fixture = new FixtureCallManager();
            var result = fixture.AddFixture(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.ReturnId));
        }

        [HttpPost("UpdateFixture")]
        public IActionResult UpdateFixture(Fixture parameter)
        {
            FixtureCallManager fixture = new FixtureCallManager();
            var result = fixture.UpdateFixture(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("DeleteFixture")]
        public IActionResult DeleteFixture(Fixture parameter)
        {
            FixtureCallManager fixture = new FixtureCallManager();
            var result = fixture.DeleteFixture(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }
    }
}
