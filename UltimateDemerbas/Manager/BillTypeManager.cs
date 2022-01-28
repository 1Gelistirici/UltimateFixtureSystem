using System.Net.Http;
using System.Threading.Tasks;
using UltimateAPI.Entities;

namespace UltimateDemerbas.Manager
{
    public class BillTypeManager : BaseManager
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BillTypeManager(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public Task<string> GetBillTypes()
        {
            return GetApi("BillType/GetBillTypes");
        }

        public Task<string> DeleteBillType(BillType parameter)
        {
            return GetApiParameter<BillType>("BillType/DeleteBillType", parameter);
        }

        public Task<string> UpdateBillType(BillType parameter)
        {
            return GetApiParameter<BillType>("BillType/UpdateBillType", parameter);
        }

        public Task<string> AddBillType(BillType parameter)
        {
            return GetApiParameter<BillType>("BillType/AddBillType", parameter);
        }
    }
}
