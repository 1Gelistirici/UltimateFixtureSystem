using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using UltimateAPI.Entities;

namespace UltimateDemerbas.Manager
{
    public class UserManager:BaseManager
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UserManager(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<string> CheckUser(User parameter)
        {
            var url = apiAdress + $"/User/CheckUser";
            var httpClient = _httpClientFactory.CreateClient("Test");
            var JsonData = GetSerilizatiob<User>(parameter);

            try
            {
                var response = await httpClient.PostAsync(url, JsonData);
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                Error(ex);
                return null;
            }
        }

        public async Task<string> GetUser(User parameter)
        {
            var url = apiAdress + $"/User/GetUser";
            var httpClient = _httpClientFactory.CreateClient("Test");
            var JsonData = GetSerilizatiob<User>(parameter);

            try
            {
                var response = await httpClient.PostAsync(url, JsonData);
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                Error(ex);
                return null;
            }
        }
        
        public async Task<string> GetUsers(User parameter)
        {
            var url = apiAdress + $"/User/GetUsers";
            var httpClient = _httpClientFactory.CreateClient("Test");
            var JsonData = GetSerilizatiob<User>(parameter);

            try
            {
                var response = await httpClient.PostAsync(url, JsonData);
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                Error(ex);
                return null;
            }
        }

        public async Task<string> ChangePassword([FromBody] User parameter)
        {
            

            var url = apiAdress + $"/User/ChangePassword";
            var httpClient = _httpClientFactory.CreateClient("Test");
            var JsonData = GetSerilizatiob<User>(parameter);

            if (parameter.Password != parameter.PasswordTry)
            {
                url = "test";
            }

            try
            {
                var response = await httpClient.PostAsync(url, JsonData);
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                Error(ex);
                return null;
            }
        }
        public async Task<string> UpdateProfile(User parameter)
        {
            var url = apiAdress + $"/User/UpdateProfile";
            var httpClient = _httpClientFactory.CreateClient("Test");
            var JsonData = GetSerilizatiob<User>(parameter);

            try
            {
                var response = await httpClient.PostAsync(url, JsonData);
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
