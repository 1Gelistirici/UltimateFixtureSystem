using System.Net.Http;
using System.Threading.Tasks;
using UltimateAPI.Entities;

namespace UltimateDemerbas.Manager
{
    public class MessageManager : BaseManager
    {
        public MessageManager(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }


        public Task<string> GetMessages(Message parameter)
        {
            return GetApiParameter<Message>("Message/GetMessages", parameter);
        }

        public Task<string> GetMessageByCompanyRefId(ReferansParameter parameter)
        {
            return GetApiParameter<ReferansParameter>("Message/GetMessageByCompanyRefId", parameter);
        }

        public Task<string> DeleteMessage(Message parameter)
        {
            return GetApiParameter<Message>("Message/DeleteMessage", parameter);
        }

        public Task<string> AddMessage(Message parameter)
        {
            return GetApiParameter<Message>("Message/AddMessage", parameter);
        }
    }
}
