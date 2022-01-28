using System;
using System.Net.Http;
using System.Threading.Tasks;
using UltimateAPI.Entities;

namespace UltimateDemerbas.Manager
{
    public class FixtureManager : BaseManager
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public FixtureManager(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public Task<string> GetFixtures()
        {
            return GetApi("Fixture/GetFixtures");
        }

        public Task<string> GetFixture(Fixture parameter)
        {
            return GetApiParameter<Fixture>("Fixture/GetFixture", parameter);
        }

        public Task<string> GetFixtureByUser(Fixture parameter)
        {
            return GetApiParameter<Fixture>("Fixture/GetFixtureByUser", parameter);
        }

        public Task<string> AddFixture(Fixture parameter)
        {
            return GetApiParameter<Fixture>("Fixture/AddFixture", parameter);
        }

        public Task<string> UpdateFixture(Fixture parameter)
        {
            return GetApiParameter<Fixture>("Fixture/UpdateFixture", parameter);
        }

        public Task<string> DeleteFixture(Fixture parameter)
        {
            return GetApiParameter<Fixture>("Fixture/DeleteFixture", parameter);
        }
    }
}
