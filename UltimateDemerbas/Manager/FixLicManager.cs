using System.Net.Http;
using System.Threading.Tasks;
using UltimateAPI.Entities;

namespace UltimateDemerbas.Manager
{
    public class FixLicManager : BaseManager
    {
        public FixLicManager(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public Task<string> AddFixLic(FixLic parameter)
        {
            return GetApiParameter<FixLic>("FixLic/AddFixLic", parameter);
        }

        public Task<string> GetFixLices(FixLic parameter)
        {
            return GetApiParameter<FixLic>("FixLic/GetFixLices", parameter);
        }

        public Task<string> DeleteFixLic(FixLic parameter)
        {
            return GetApiParameter<FixLic>("FixLic/DeleteFixLic", parameter);
        }

    }
}
