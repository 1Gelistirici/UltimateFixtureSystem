using Microsoft.AspNetCore.Mvc;
using UltimateAPI.CallManager;
using UltimateAPI.Entities;

namespace UltimateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SituationController : ControllerBase
    {
        [HttpPost("AddSituation")]
        public IActionResult AddSituation(Situation parameter)
        {
            SituationCallManager license = new SituationCallManager();
            var result = license.AddSituation(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpGet("GetSituations")]
        public IActionResult GetSituations()
        {
            SituationCallManager situation = new SituationCallManager();
            var result = situation.GetSituations();
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpGet("GetSituationByCompanyRefId")]
        public IActionResult GetSituationByCompanyRefId(ReferansParameter parameter)
        {
            SituationCallManager situation = new SituationCallManager();
            var result = situation.GetSituationByCompanyRefId(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("DeleteSituation")]
        public IActionResult DeleteLicense(Situation parameter)
        {
            SituationCallManager situation = new SituationCallManager();
            var result = situation.DeleteSituation(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("UpdateSituation")]
        public IActionResult UpdateSituation(Situation parameter)
        {
            SituationCallManager situation = new SituationCallManager();
            var result = situation.UpdateSituation(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }
    }
}
