using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using UltimateAPI.Entities;
using UltimateDemerbas.Manager;

namespace UltimateDemerbas.Controllers
{
    public class CategoryController : BaseController
    {
        protected override int PageNumber { get; set; } = 1;
        private readonly IHttpClientFactory _httpClientFactory;
        CategoryManager category;
        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            category = new CategoryManager(_httpClientFactory);
        }


        public IActionResult Index()
        {
            return View();
        }


        public IActionResult GetCategories()
        {
            var result = category.GetCategories();
            return Content(result.Result);
        }

        public IActionResult DeleteCategory([FromBody] Category parameter)
        {
            parameter.UserId = Convert.ToInt32(Request.Cookies["id"]);
            var result = category.DeleteCategory(parameter);
            return Content(result.Result);
        }

        public IActionResult AddCategory([FromBody] Category parameter)
        {
            parameter.UserId = Convert.ToInt32(Request.Cookies["id"]);
            var result = category.AddCategory(parameter);
            return Content(result.Result);
        }

        public IActionResult UpdateCategory([FromBody] Category parameter)
        {
            parameter.UserId = Convert.ToInt32(Request.Cookies["id"]);
            var result = category.UpdateCategory(parameter);
            return Content(result.Result);
        }
    }
}
