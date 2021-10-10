using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UltimateDemerbas.Entities;

namespace UltimateDemerbas.Manager
{
    public class AccessoryModelManager : BaseManager
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AccessoryModelManager(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<string> GetAccessoryModels()
        {
            var url = apiAdress + $"/AccessoryModel/GetAccessoryModels";
            var httpClient = _httpClientFactory.CreateClient("Test"); ;

            try
            {
                var response = await httpClient.GetAsync(url);
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<string> DeleteAccessoryModel(AccessoryModel parameter)
        {
            var url = apiAdress + $"/AccessoryModel/DeleteAccessoryModel";
            var httpClient = _httpClientFactory.CreateClient("Test"); ;
            var JsonData = GetSerilizatiob<AccessoryModel>(parameter);

            try
            {
                var response = await httpClient.PostAsync(url, JsonData);
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<string> UpdateAccessoryModel(AccessoryModel parameter)
        {
            var url = apiAdress + $"/AccessoryModel/UpdateAccessoryModel";
            var httpClient = _httpClientFactory.CreateClient("Test"); ;
            var JsonData = GetSerilizatiob<AccessoryModel>(parameter);

            try
            {
                var response = await httpClient.PostAsync(url, JsonData);
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<string> AddAccessoryModel(AccessoryModel parameter)
        {
            var url = apiAdress + $"/AccessoryModel/AddAccessoryModel";
            var httpClient = _httpClientFactory.CreateClient("Test"); ;
            var JsonData = GetSerilizatiob<AccessoryModel>(parameter);

            try
            {
                var response = await httpClient.PostAsync(url, JsonData);
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
