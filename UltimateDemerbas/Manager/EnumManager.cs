using System.Net.Http;
using System.Threading.Tasks;

namespace UltimateDemerbas.Manager
{
    public class EnumManager : BaseManager
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public EnumManager(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public Task<string> GetIsActiveTypes()
        {
            return GetApi("Enum/GetIsActiveTypes");
        }

        public Task<string> GetItemStatuTypes()
        {
            return GetApi("Enum/GetItemStatuTypes");
        }

        public Task<string> GetItemTypeTypes()
        {
            return GetApi("Enum/GetItemTypeTypes");
        }

    }
}
