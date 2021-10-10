using System;
using System.Net.Http;
using System.Threading.Tasks;
using UltimateDemerbas.Entities;

namespace UltimateDemerbas.Manager
{
    public class AccessoryManager:BaseManager
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AccessoryManager(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> GetAccessories()
        {
            var url = apiAdress + $"/Accessory/GetAccessories";
            var httpClient = _httpClientFactory.CreateClient("Test"); ;

            try
            {
                var response = await httpClient.GetAsync(url);
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                Error(ex);
                return null;
            }
        }
        
        public async Task<string> GetAccessory(Accessory parameter)
        {
            var url = apiAdress + $"/Accessory/GetAccessory";
            var httpClient = _httpClientFactory.CreateClient("Test"); ;
            var JsonData = GetSerilizatiob<Accessory>(parameter);

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

        public async Task<string> DeleteAccessory(Accessory parameter)
        {
            var url = apiAdress + $"/Accessory/DeleteAccessory";
            var httpClient = _httpClientFactory.CreateClient("Test"); ;
            var JsonData = GetSerilizatiob<Accessory>(parameter);

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

        public async Task<string> UpdateAccessory(Accessory parameter)
        {
            var url = apiAdress + $"/Accessory/UpdateAccessory";
            var httpClient = _httpClientFactory.CreateClient("Test"); ;
            var JsonData = GetSerilizatiob<Accessory>(parameter);

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

        public async Task<string> AddAccessory(Accessory parameter)
        {
            var url = apiAdress + $"/Accessory/AddAccessory";
            var httpClient = _httpClientFactory.CreateClient("Test"); ;
            var JsonData = GetSerilizatiob<Accessory>(parameter);

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
