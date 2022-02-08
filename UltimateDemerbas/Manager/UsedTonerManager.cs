using System.Net.Http;
using System.Threading.Tasks;
using UltimateAPI.Entities;

namespace UltimateDemerbas.Manager
{
    public class UsedTonerManager : BaseManager
    {
        public UsedTonerManager(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public Task<string> GetUsedToners()
        {
            return GetApi("UsedToner/GetUsedToners");
        }

        public Task<string> GetUsedToner(UsedToner parameter)
        {
            return GetApiParameter<UsedToner>("UsedToner/GetUsedToner", parameter);
        }

        public Task<string> AddUsedToner(UsedToner parameter)
        {
            return GetApiParameter<UsedToner>("UsedToner/AddUsedToner", parameter);
        }

        public Task<string> UpdateUsedToner(UsedToner parameter)
        {
            return GetApiParameter<UsedToner>("UsedToner/UpdateUsedToner", parameter);
        }

        public Task<string> DeleteUsedToner(UsedToner parameter)
        {
            return GetApiParameter<UsedToner>("UsedToner/DeleteUsedToner", parameter);
        }
    }
}
