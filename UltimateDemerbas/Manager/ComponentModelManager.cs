using System.Net.Http;
using System.Threading.Tasks;
using UltimateAPI.Entities;

namespace UltimateDemerbas.Manager
{
    public class ComponentModelManager : BaseManager
    {
        public ComponentModelManager(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }


        public Task<string> GetComponentModels()
        {
            return GetApi("ComponentModel/GetComponentModels");
        }

        public Task<string> DeleteComponentModel(ComponentModel parameter)
        {
            return GetApiParameter<ComponentModel>("ComponentModel/DeleteComponentModel", parameter);
        }

        public Task<string> UpdateComponentModel(ComponentModel parameter)
        {
            return GetApiParameter<ComponentModel>("ComponentModel/UpdateComponentModel", parameter);
        }

        public Task<string> AddComponentModel(ComponentModel parameter)
        {
            return GetApiParameter<ComponentModel>("ComponentModel/AddComponentModel", parameter);
        }
    }
}
