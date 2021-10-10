using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UltimateDemerbas.Entities;

namespace UltimateDemerbas.Manager
{
    public class SituationManager:BaseManager
    {
            private readonly IHttpClientFactory _httpClientFactory;

            public SituationManager(IHttpClientFactory httpClientFactory)
            {
                _httpClientFactory = httpClientFactory;
            }


            public async Task<string> GetSituations()
            {
                var url = apiAdress + $"/Situation/GetSituations";
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

            public async Task<string> DeleteSituation(Situation parameter)
            {
                var url = apiAdress + $"/Situation/DeleteSituation";
                var httpClient = _httpClientFactory.CreateClient("Test"); ;
                var JsonData = GetSerilizatiob<Situation>(parameter);

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

            public async Task<string> UpdateSituation(Situation parameter)
            {
                var url = apiAdress + $"/Situation/UpdateSituation";
                var httpClient = _httpClientFactory.CreateClient("Test"); ;
                var JsonData = GetSerilizatiob<Situation>(parameter);

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

            public async Task<string> AddSituation(Situation parameter)
            {
                var url = apiAdress + $"/Situation/AddSituation";
                var httpClient = _httpClientFactory.CreateClient("Test"); ;
                var JsonData = GetSerilizatiob<Situation>(parameter);

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
