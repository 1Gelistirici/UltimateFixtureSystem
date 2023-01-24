using System.Net.Http;
using System.Threading.Tasks;
using UltimateAPI.Entities;

namespace UltimateDemerbas.Manager
{
    public class MenuManager : BaseManager
    {
        public MenuManager(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }


        public Task<string> GetMenu()
        {
            return GetApi("Menu/GetMenu");
        }

        public Task<string> AddMenu(Menu parameter)
        {
            return GetApiParameter<Menu>("Menu/AddMenu", parameter);
        }

        public Task<string> UpdateMenu(Menu parameter)
        {
            return GetApiParameter<Menu>("Menu/UpdateMenu", parameter);
        }

        public Task<string> DeleteMenu(Menu parameter)
        {
            return GetApiParameter<Menu>("Menu/DeleteMenu", parameter);
        }

    }
}
