using System.Collections.Generic;
using UltimateAPI.Entities;
using UltimateAPI.Manager;

namespace UltimateAPI.CallManager
{
    public class CategoryCallManager
    {
        public UltimateResult<List<Category>> GetCategories()
        {
            return CategoryManager.Instance.GetCategories();
        }
        public UltimateResult<List<Category>> GetCategoryByCompanyRefId(ReferansParameter parameter)
        {
            return CategoryManager.Instance.GetCategoryByCompanyRefId(parameter);
        }

        public UltimateResult<List<Category>> DeleteCategory(Category parameter)
        {
            return CategoryManager.Instance.DeleteCategory(parameter);
        }

        public UltimateResult<List<Category>> AddCategory(Category parameter)
        {
            return CategoryManager.Instance.AddCategory(parameter);
        }

        public UltimateResult<List<Category>> UpdateCategory(Category parameter)
        {
            return CategoryManager.Instance.UpdateCategory(parameter);
        }
    }
}
