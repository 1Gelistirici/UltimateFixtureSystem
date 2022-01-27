using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using UltimateAPI.Entities;

namespace UltimateDemerbas.Manager
{
    public class UserManager : BaseManager
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UserManager(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public Task<string> CheckUser(User parameter)
        {
            return GetApiParameter<User>("User/CheckUser", parameter);
        }

        public Task<string> GetUser(User parameter)
        {
            return GetApiParameter<User>("User/GetUser", parameter);
        }

        public Task<string> GetUsers(User parameter)
        {
            return GetApiParameter<User>("User/GetUsers", parameter);
        }

        public async Task<string> ChangePassword([FromBody] User parameter) //Todo Bakılacak Neden bırada kontroller gerçekleşiyor
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

        public Task<string> UpdateProfile(User parameter)
        {
            return GetApiParameter<User>("User/UpdateProfile", parameter);
        }

    }
}
