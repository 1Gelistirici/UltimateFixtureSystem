using System.Net.Http;
using System.Threading.Tasks;
using UltimateAPI.Entities;

namespace UltimateDemerbas.Manager
{
    public class DepreciationManager : BaseManager
    {
        public DepreciationManager(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public Task<string> FixedAnnualAmount(FixedAnnualAmountModel parameter)
        {
            return GetApiParameter<FixedAnnualAmountModel>("Depreciation/FixedAnnualAmount", parameter);
        }

        public Task<string> DecreasingBalance(DecreasingBalanceModel parameter)
        {
            return GetApiParameter<DecreasingBalanceModel>("Depreciation/DecreasingBalance", parameter);
        }

        public Task<string> DepreciationByProductionAmount(DepreciationByProductionAmountModel parameter)
        {
            return GetApiParameter<DepreciationByProductionAmountModel>("Depreciation/DepreciationByProductionAmount", parameter);
        }

    }
}
