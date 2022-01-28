using System.Net.Http;
using System.Threading.Tasks;
using UltimateAPI.Entities;

namespace UltimateDemerbas.Manager
{
    public class MessageManager : BaseManager
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MessageManager(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public Task<string> GetMessages(Message parameter)
        {
            return GetApiParameter<Message>("Message/GetMessages", parameter);
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
