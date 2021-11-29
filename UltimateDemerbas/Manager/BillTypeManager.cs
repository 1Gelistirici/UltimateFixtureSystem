using System;
using System.Threading.Tasks;
using System.Net.Http;
using UltimateAPI.Entities;

namespace UltimateDemerbas.Manager
{
    public class BillTypeManager : BaseManager
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BillTypeManager(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<string> GetBillTypes()
        {
            var url = apiAdress + $"/BillType/GetBillTypes";
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

        public async Task<string> DeleteBillType(BillType parameter)
        {
            var url = apiAdress + $"/BillType/DeleteBillType";
            var httpClient = _httpClientFactory.CreateClient("Test"); ;
            var JsonData = GetSerilizatiob<BillType>(parameter);

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

        public async Task<string> UpdateBillType(BillType parameter)
        {
            var url = apiAdress + $"/BillType/UpdateBillType";
            var httpClient = _httpClientFactory.CreateClient("Test"); ;
            var JsonData = GetSerilizatiob<BillType>(parameter);

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

        public async Task<string> AddBillType(BillType parameter)
        {
            var url = apiAdress + $"/BillType/AddBillType";
            var httpClient = _httpClientFactory.CreateClient("Test"); ;
            var JsonData = GetSerilizatiob<BillType>(parameter);

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
