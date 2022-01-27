using System.Net.Http;
using System.Threading.Tasks;
using UltimateAPI.Entities;

namespace UltimateDemerbas.Manager
{
    public class TonerManager : BaseManager
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TonerManager(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public Task<string> GetToners()
        {
            return GetApi("Toner/GetToners");
        }

        public Task<string> DeleteToner(Toner parameter)
        {
            return GetApiParameter<Toner>("Toner/DeleteToner", parameter);
        }

        public Task<string> UpdateToner(Toner parameter)
        {
            return GetApiParameter<Toner>("Toner/UpdateToner", parameter);
        }

        public Task<string> AddToner(Toner parameter)
        {
            return GetApiParameter<Toner>("Toner/AddToner", parameter);
        }





        //public async Task<string> GetToner(Login login)
        //{
        //    var url = $"https://localhost:44354/api/Toner/GetToner";
        //    var httpClient = _httpClientFactory.CreateClient("Test"); ;
        //    var JsonData = GetSerilizatiob<Login>(login);

        //    try
        //    {
        //        var response = await httpClient.PostAsync(url, JsonData);
        //        return await response.Content.ReadAsStringAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

        //public async Task<string> GetToners()
        //{
        //    var url = $"https://localhost:44354/api/Toner/GetToners";
        //    var httpClient = _httpClientFactory.CreateClient("Test"); ;

        //    try
        //    {
        //        var response = await httpClient.GetAsync(url);
        //        return await response.Content.ReadAsStringAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

    }
}
