using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UltimateAPI.Entities;

namespace UltimateDemerbas.Manager
{
    public class ComponentManager : BaseManager
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ComponentManager(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> GetComponents()
        {
            var url = apiAdress + $"/Component/GetComponents";
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

        public async Task<string> DeleteComponent(Component parameter)
        {
            var url = apiAdress + $"/Component/DeleteComponent";
            var httpClient = _httpClientFactory.CreateClient("Test"); ;
            var JsonData = GetSerilizatiob<Component>(parameter);

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

        public async Task<string> UpdateComponent(Component parameter)
        {
            var url = apiAdress + $"/Component/UpdateComponent";
            var httpClient = _httpClientFactory.CreateClient("Test"); ;
            var JsonData = GetSerilizatiob<Component>(parameter);

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

        public async Task<string> AddComponent(Component parameter)
        {
            var url = apiAdress + $"/Component/AddComponent";
            var httpClient = _httpClientFactory.CreateClient("Test"); ;
            var JsonData = GetSerilizatiob<Component>(parameter);

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
