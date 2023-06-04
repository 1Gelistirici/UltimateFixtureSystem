using System.Net.Http;
using System.Threading.Tasks;
using UltimateAPI.Entities;

namespace UltimateDemerbas.Manager
{
    public class FeedbackManager : BaseManager
    {
        public FeedbackManager(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public Task<string> GetFeedbackByUser(ReferansParameter parameter)
        {
            return GetApiParameter<ReferansParameter>("Feedback/GetFeedbackByUser", parameter);
        }

        public Task<string> AddFeedback(Feedback parameter)
        {
            return GetApiParameter<Feedback>("Feedback/AddFeedback", parameter);
        }

    }
}
