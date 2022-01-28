using System.Net.Http;
using System.Threading.Tasks;
using UltimateAPI.Entities;

namespace UltimateDemerbas.Manager
{
    public class AccessoryManager : BaseManager
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AccessoryManager(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public Task<string> GetAccessories()
        {
            return GetApi("Accessory/GetAccessories");
        }

        public Task<string> GetAccessory(Accessory parameter)
        {
            return GetApiParameter<Accessory>("Accessory/GetAccessory", parameter);
        }

        public Task<string> DeleteAccessory(Accessory parameter)
        {
            return GetApiParameter<Accessory>("Accessory/DeleteAccessory", parameter);
        }

        public Task<string> UpdateAccessory(Accessory parameter)
        {
            return GetApiParameter<Accessory>("Accessory/UpdateAccessory", parameter);
        }

        public Task<string> AddAccessory(Accessory parameter)
        {
            return GetApiParameter<Accessory>("Accessory/AddAccessory", parameter);
        }
    }
}
