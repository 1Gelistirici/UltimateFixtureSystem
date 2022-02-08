using System.Net.Http;
using System.Threading.Tasks;

namespace UltimateDemerbas.Manager
{
    public class LayoutManager : BaseManager
    {
        public LayoutManager(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }



        public Task<string> GetMenus()
        {
            return GetApi("Layout/GetMenus");
        }




    }
}
