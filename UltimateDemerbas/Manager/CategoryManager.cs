using System;
using System.Net.Http;
using System.Threading.Tasks;
using UltimateDemerbas.Entities;

namespace UltimateDemerbas.Manager
{
    public class CategoryManager : BaseManager
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryManager(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> GetCategories()
        {
            var url = apiAdress + $"/Category/GetCategories";
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

        public async Task<string> DeleteCategory(Category parameter)
        {
            var url = apiAdress + $"/Category/DeleteCategory";
            var httpClient = _httpClientFactory.CreateClient("Test"); ;
            var JsonData = GetSerilizatiob<Category>(parameter);

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

        public async Task<string> UpdateCategory(Category parameter)
        {
            var url = apiAdress + $"/Category/UpdateCategory";
            var httpClient = _httpClientFactory.CreateClient("Test"); ;
            var JsonData = GetSerilizatiob<Category>(parameter);

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

        public async Task<string> AddCategory(Category parameter)
        {
            var url = apiAdress + $"/Category/AddCategory";
            var httpClient = _httpClientFactory.CreateClient("Test"); ;
            var JsonData = GetSerilizatiob<Category>(parameter);

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
