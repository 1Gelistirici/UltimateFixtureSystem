using System;
using System.Threading.Tasks;
using System.Net.Http;
using UltimateAPI.Entities;
using System.Text.Json;
using System.Text;

namespace UltimateDemerbas.Manager
{
    public class UserRoleTest
    {
        private readonly HttpClient _httpClient;
        public UserRoleTest(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }



        public async Task<UserRole> PostMyDataAsync(UserRole requestData)
        {
            var requestJson = JsonSerializer.Serialize(requestData);
            var requestContent = new StringContent(requestJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("/UserRole/GetRole", requestContent);

            if (response.IsSuccessStatusCode)
            {
                var responseJson = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<UserRole>(responseJson);
            }
            else
            {
                throw new Exception($"Failed to POST data: {response.StatusCode}");
            }
        }




    }
}
