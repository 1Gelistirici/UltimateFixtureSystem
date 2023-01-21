using System.Net.Http;
using System.Threading.Tasks;

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

        public Task<string> GetLicensesTypes()
        {
            return GetApi("LicanseType/GetLicensesTypes");
        }

    }
}
