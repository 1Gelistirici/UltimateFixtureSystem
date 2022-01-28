using System;
using System.Net.Http;
using System.Threading.Tasks;
using UltimateAPI.Entities;

namespace UltimateDemerbas.Manager
{
    public class FixtureModelManager : BaseManager
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FixtureModelManager(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public Task<string> GetFixtureModels()
        {
            return GetApi("FixtureModel/GetFixtureModels");
        }

        public Task<string> DeleteFixtureModel(FixtureModel parameter)
        {
            return GetApiParameter<FixtureModel>("FixtureModel/DeleteFixtureModel", parameter);
        }

        public Task<string> UpdateFixtureModel(FixtureModel parameter)
        {
            return GetApiParameter<FixtureModel>("FixtureModel/UpdateFixtureModel", parameter);
        }

        public Task<string> AddFixtureModel(FixtureModel parameter)
        {
            return GetApiParameter<FixtureModel>("FixtureModel/AddFixtureModel", parameter);
        }
    }
}
