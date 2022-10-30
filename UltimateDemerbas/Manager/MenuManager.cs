using System.Net.Http;
using System.Threading.Tasks;

namespace UltimateDemerbas.Manager
{
    public class MenuManager : BaseManager
    {
        public MenuManager(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }


        public Task<string> GetMenus()
        {
            return GetApi("Menu/GetMenus");
        }












    }
}
