using System.Net.Http;
using System.Threading.Tasks;
using UltimateAPI.Entities;

namespace UltimateDemerbas.Manager
{
    public class BillManager : BaseManager
    {
        public BillManager(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
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

        public Task<string> DeleteBillItem(ReferansParameter parameter)
        {
            return GetApiParameter<ReferansParameter>("Bill/DeleteBillItem", parameter);
        }



    }
}
