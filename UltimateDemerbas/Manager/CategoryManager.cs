using System.Net.Http;
using System.Threading.Tasks;
using UltimateAPI.Entities;

namespace UltimateDemerbas.Manager
{
    public class CategoryManager : BaseManager
    {
        public CategoryManager(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public Task<string> GetCategories()
        {
            return GetApi("Category/GetCategories");
        }

        public Task<string> DeleteCategory(Category parameter)
        {
            return GetApiParameter<Category>("Category/DeleteCategory", parameter);
        }

        public Task<string> GetCategoryByCompanyRefId(ReferansParameter parameter)
        {
            return GetApiParameter<ReferansParameter>("Category/GetCategoryByCompanyRefId", parameter);
        }

        public Task<string> UpdateCategory(Category parameter)
        {
            return GetApiParameter<Category>("Category/UpdateCategory", parameter);
        }

        public Task<string> AddCategory(Category parameter)
        {
            return GetApiParameter<Category>("Category/AddCategory", parameter);
        }
    }
}
