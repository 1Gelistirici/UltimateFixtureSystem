using System.Net.Http;
using System.Threading.Tasks;
using UltimateAPI.Entities;

namespace UltimateDemerbas.Manager
{
    public class ItemHistoryManager : BaseManager
    {
        public ItemHistoryManager(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }


        public Task<string> GetItemHistoryByCompany(ReferansParameter parameter)
        {
            return GetApiParameter<ReferansParameter>("ItemHistory/GetItemHistoryByCompany", parameter);
        }

        public Task<string> AddItemHistory(ItemHistory parameter)
        {
            return GetApiParameter<ItemHistory>("ItemHistory/AddItemHistory", parameter);
        }
    }
}
