using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UltimateDemerbas.Controllers;
using UltimateDemerbas.Entities;

namespace UltimateDemerbas.Manager
{
    public class LoginManager:BaseManager
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LoginManager(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<string> Authenticate(User user)
        {
            var url = apiAdress + $"/Login/Authenticate";
            var httpClient = _httpClientFactory.CreateClient("Test"); ;
            var JsonData = GetSerilizatiob<User>(user);

            try
            {
                var response = await httpClient.PostAsync(url, JsonData);
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
