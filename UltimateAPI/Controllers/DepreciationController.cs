using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using UltimateAPI.Entities;
using UltimateAPI.Tool;

namespace UltimateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepreciationController : ControllerBase
    {

        [HttpPost("FixedAnnualAmount")]
        public IActionResult FixedAnnualAmount(FixedAnnualAmountModel parameter)
        {
            UltimateResult<List<FixedAnnualAmountResult>> result = DepreciationCalculator.Instance.FixedAnnualAmount(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("NormalDepreciation")]
        public IActionResult NormalDepreciation(NormalDepreciationModel parameter)
        {
            UltimateResult<List<NormalDepreciationResult>> result = DepreciationCalculator.Instance.NormalDepreciation(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("DecreasingBalance")]
        public IActionResult DecreasingBalance(DecreasingBalanceModel parameter)
        {
            UltimateResult<DecreasingBalanceResult> result = DepreciationCalculator.Instance.DecreasingBalance(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }


        [HttpPost("DecreasingBalanceV1")]
        public IActionResult DecreasingBalanceV1(DecreasingBalanceV1Model parameter)
        {
            UltimateResult<List<DecreasingBalanceV1Result>> result = DepreciationCalculator.Instance.DecreasingBalanceV1(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("DepreciationByProductionAmount")]
        public IActionResult DepreciationByProductionAmount(DepreciationByProductionAmountModel parameter)
        {
            UltimateResult<DepreciationByProductionAmountResult> result = DepreciationCalculator.Instance.DepreciationByProductionAmount(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }



    }
}
