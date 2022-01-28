﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using UltimateAPI.Entities;

namespace UltimateDemerbas.Manager
{
    public class CategoryManager : BaseManager
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryManager(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public Task<string> GetCategories()
        {
            return GetApi("Category/GetCategories");
        }

        public Task<string> DeleteCategory(Category parameter)
        {
            return GetApiParameter<Category>("Category/DeleteCategory", parameter);
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
