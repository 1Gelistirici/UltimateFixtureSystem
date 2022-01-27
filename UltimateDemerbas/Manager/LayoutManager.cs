using System;
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



        public async Task<string> GetMenus()
        {
            var url = apiAdress + $"/Layout/GetMenus";
            var httpClient = _httpClientFactory.CreateClient("Test"); ;

            try
            {
                var response = await httpClient.GetAsync(url);
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                Error(ex);
                return null;
            }
        }




    }
}
