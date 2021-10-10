using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UltimateAPI.Entities;

namespace UltimateDemerbas.Manager
{
    public class BillManager : BaseManager
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BillManager(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<string> GetBills()
        {
            var url = apiAdress + $"/Bill/GetBills";
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

        public async Task<string> DeleteBill(Bill parameter)
        {
            var url = apiAdress + $"/Bill/DeleteBill";
            var httpClient = _httpClientFactory.CreateClient("Test"); ;
            var JsonData = GetSerilizatiob<Bill>(parameter);

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

        public async Task<string> UpdateBill(Bill parameter)
        {
            var url = apiAdress + $"/Bill/UpdateBill";
            var httpClient = _httpClientFactory.CreateClient("Test"); ;
            var JsonData = GetSerilizatiob<Bill>(parameter);

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

        public async Task<string> AddBill(Bill parameter)
        {
            var url = apiAdress + $"/Bill/AddBill";
            var httpClient = _httpClientFactory.CreateClient("Test"); ;
            var JsonData = GetSerilizatiob<Bill>(parameter);

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
