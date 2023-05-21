using System.Net.Http;
using System.Threading.Tasks;
using UltimateAPI.Entities;

namespace UltimateDemerbas.Manager
{
    public class ComponentManager : BaseManager
    {
        public ComponentManager(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public Task<string> GetComponents()
        {
            return GetApi("Component/GetComponents");
        }

        public Task<string> GetComponentByCompanyRefId(ReferansParameter parameter)
        {
            return GetApiParameter<ReferansParameter>("Component/GetComponentByCompanyRefId", parameter);
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
