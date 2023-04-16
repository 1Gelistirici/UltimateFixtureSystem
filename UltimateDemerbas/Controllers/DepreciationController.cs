using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using UltimateAPI.Entities;
using UltimateDemerbas.Manager;
using UltimateDemerbas.Models.Tool;

namespace UltimateDemerbas.Controllers
{
    [CheckAuthorize]
    public class DepreciationController : BaseController
    {
        protected override int PageNumber { get; set; } = 53;
        private readonly IHttpClientFactory _httpClientFactory;
        DepreciationManager depreciation;
        public DepreciationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            depreciation = new DepreciationManager(_httpClientFactory);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FixedAnnualAmount([FromBody] FixedAnnualAmountModel parameter)
        {
            var result = depreciation.FixedAnnualAmount(parameter);
            return Content(result.Result);
        }

        public IActionResult NormalDepreciation([FromBody] NormalDepreciationModel parameter)
        {
            var result = depreciation.NormalDepreciation(parameter);
            return Content(result.Result);
        }

        public IActionResult DecreasingBalance([FromBody] DecreasingBalanceModel parameter)
        {
            var result = depreciation.DecreasingBalance(parameter);
            return Content(result.Result);
        }

        public IActionResult DecreasingBalanceV1([FromBody] DecreasingBalanceV1Model parameter)
        {
            var result = depreciation.DecreasingBalanceV1(parameter);
            return Content(result.Result);
        }

        public IActionResult DepreciationByProductionAmount([FromBody] DepreciationByProductionAmountModel parameter)
        {
            var result = depreciation.DepreciationByProductionAmount(parameter);
            return Content(result.Result);
        }
    }
}
