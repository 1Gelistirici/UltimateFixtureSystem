using System.Net.Http;
using System.Threading.Tasks;

namespace UltimateDemerbas.Manager
{
    public class LayoutManager : BaseManager
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LayoutManager(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }



        public Task<string> GetMenus()
        {
            return GetApi("Layout/GetMenus");
        }




    }
}
