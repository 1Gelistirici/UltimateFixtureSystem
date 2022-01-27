using System;
using System.Net.Http;
using System.Threading.Tasks;
using UltimateAPI.Entities;

namespace UltimateDemerbas.Manager
{
    public class BillManager : BaseManager
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BillManager(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public Task<string> GetBills()
        {
            return GetApi("Bill/GetBills");
        }

        public Task<string> DeleteBill(Bill parameter)
        {
            return GetApiParameter<Bill>("Bill/DeleteBill", parameter);
        }

        public Task<string> UpdateBill(Bill parameter)
        {
            return GetApiParameter<Bill>("Bill/UpdateBill", parameter);
        }

        public Task<string> AddBill(Bill parameter)
        {
            return GetApiParameter<Bill>("Bill/AddBill", parameter);
        }
    }
}
