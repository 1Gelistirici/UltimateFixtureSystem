using System.Net.Http;
using System.Threading.Tasks;
using UltimateAPI.Entities;

namespace UltimateDemerbas.Manager
{
    public class ComponentManager : BaseManager
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ComponentManager(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public Task<string> GetComponents()
        {
            return GetApi("Component/GetComponents");
        }

        public Task<string> DeleteComponent(Component parameter)
        {
            return GetApiParameter<Component>("Component/DeleteComponent", parameter);
        }

        public Task<string> UpdateComponent(Component parameter)
        {
            return GetApiParameter<Component>("Component/UpdateComponent", parameter);
        }

        public Task<string> AddComponent(Component parameter)
        {
            return GetApiParameter<Component>("Component/AddComponent", parameter);
        }
    }
}
