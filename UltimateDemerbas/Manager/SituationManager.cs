using System.Net.Http;
using System.Threading.Tasks;
using UltimateAPI.Entities;

namespace UltimateDemerbas.Manager
{
    public class SituationManager : BaseManager
    {
        public SituationManager(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }


        public Task<string> GetSituations()
        {
            return GetApi("Situation/GetSituations");
        }

        public Task<string> GetSituationByCompanyRefId()
        {
            return GetApi("Situation/GetSituationByCompanyRefId");
        }

        public Task<string> DeleteSituation(Situation parameter)
        {
            return GetApiParameter<Situation>("Situation/DeleteSituation", parameter);
        }

        public Task<string> UpdateSituation(Situation parameter)
        {
            return GetApiParameter<Situation>("Situation/UpdateSituation", parameter);
        }

        public Task<string> AddSituation(Situation parameter)
        {
            return GetApiParameter<Situation>("Situation/AddSituation", parameter);
        }
    }
}
