using System;
using System.Net.Http;
using System.Threading.Tasks;
using UltimateDemerbas.Entities;

namespace UltimateDemerbas.Manager
{
    public class MessageManager:BaseManager
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MessageManager(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<string> GetMessages(Message parameter)
        {
            var url = apiAdress + $"/Message/GetMessages";
            var httpClient = _httpClientFactory.CreateClient("Test"); ;
            var JsonData = GetSerilizatiob<Message>(parameter);

            try
            {
                var response = await httpClient.PostAsync(url, JsonData);
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                Error(ex);
                return null;
            }
        }

        public async Task<string> DeleteMessage(Message parameter)
        {
            var url = apiAdress + $"/Message/DeleteMessage";
            var httpClient = _httpClientFactory.CreateClient("Test"); ;
            var JsonData = GetSerilizatiob<Message>(parameter);

            try
            {
                var response = await httpClient.PostAsync(url, JsonData);
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                Error(ex);
                return null;
            }
        }

        public async Task<string> AddMessage(Message parameter)
        {
            var url =apiAdress+ $"/Message/AddMessage";
            var httpClient = _httpClientFactory.CreateClient("Test"); ;
            var JsonData = GetSerilizatiob<Message>(parameter);

            try
            {
                var response = await httpClient.PostAsync(url, JsonData);
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                Error(ex);
                return null;
            }
        }
    }
}
