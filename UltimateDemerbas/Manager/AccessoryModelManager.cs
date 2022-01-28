using System;
using System.Net.Http;
using System.Threading.Tasks;
using UltimateAPI.Entities;

namespace UltimateDemerbas.Manager
{
    public class AccessoryModelManager : BaseManager
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AccessoryModelManager(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public Task<string> GetAccessoryModels()
        {
            return GetApi("AccessoryModel/GetAccessoryModels");
        }

        public Task<string> DeleteAccessoryModel(AccessoryModel parameter)
        {
            return GetApiParameter<AccessoryModel>("AccessoryModel/DeleteAccessoryModel", parameter);
        }

        public Task<string> UpdateAccessoryModel(AccessoryModel parameter)
        {
            return GetApiParameter<AccessoryModel>("AccessoryModel/UpdateAccessoryModel", parameter);
        }

        public Task<string> AddAccessoryModel(AccessoryModel parameter)
        {
            return GetApiParameter<AccessoryModel>("AccessoryModel/AddAccessoryModel", parameter);
        }
    }
}
