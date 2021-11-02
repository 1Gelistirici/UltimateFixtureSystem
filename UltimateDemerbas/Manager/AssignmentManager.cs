using System;
using System.Net.Http;
using System.Threading.Tasks;
using UltimateAPI.Entities;
using UltimateDemerbas.Entities;

namespace UltimateDemerbas.Manager
{
    public class AssignmentManager : BaseManager
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AssignmentManager(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> GetAssignments()
        {
            var url = apiAdress + $"/Assignment/GetAssignments";
            var httpClient = _httpClientFactory.CreateClient("Test"); ;

            try
            {
                var response = await httpClient.GetAsync(url);
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<string> DeleteAssignment(Assignment parameter)
        {
            var url = apiAdress + $"/Assignment/DeleteAssignment";
            var httpClient = _httpClientFactory.CreateClient("Test"); ;
            var JsonData = GetSerilizatiob<Assignment>(parameter);

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

        public async Task<string> UpdateAssignment(Assignment parameter)
        {
            var url = apiAdress + $"/Assignment/UpdateAssignment";
            var httpClient = _httpClientFactory.CreateClient("Test"); ;
            var JsonData = GetSerilizatiob<Assignment>(parameter);

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

        public async Task<string> AddAssignment(Assignment parameter)
        {
            var url = apiAdress + $"/Assignment/AddAssignment";
            var httpClient = _httpClientFactory.CreateClient("Test"); ;
            var JsonData = GetSerilizatiob<Assignment>(parameter);

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

        public async Task<string> GetAssignmentUser()
        {
            var url = apiAdress + $"/Assignment/GetAssignmentUser";
            var httpClient = _httpClientFactory.CreateClient("Test"); ;

            try
            {
                var response = await httpClient.GetAsync(url);
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
