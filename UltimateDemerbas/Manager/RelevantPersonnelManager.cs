using System.Net.Http;
using System.Threading.Tasks;
using UltimateAPI.Entities;

namespace UltimateDemerbas.Manager
{
    public class RelevantPersonnelManager : BaseManager
    {
        public RelevantPersonnelManager(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }


        public Task<string> GetRelevantPersonnels(ReferansParameter parameter)
        {
            return GetApiParameter<ReferansParameter>("RelevantPersonnel/GetRelevantPersonnels", parameter);
        }

        public Task<string> DeleteRelevantPersonnel(ReferansParameter parameter)
        {
            return GetApiParameter<ReferansParameter>("RelevantPersonnel/DeleteRelevantPersonnel", parameter);
        }

        public Task<string> AddRelevantPersonnel(RelevantPersonnel parameter)
        {
            return GetApiParameter<RelevantPersonnel>("RelevantPersonnel/AddRelevantPersonnel", parameter);
        }
    }
}
