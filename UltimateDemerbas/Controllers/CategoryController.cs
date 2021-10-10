using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using UltimateDemerbas.Entities;
using UltimateDemerbas.Manager;

namespace UltimateDemerbas.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult GetCategories()
        {
            CategoryManager category = new CategoryManager(_httpClientFactory);
            var result = category.GetCategories();

            return Content(result.Result);
        }

        public IActionResult DeleteCategory([FromBody] Category parameter)
        {
            parameter.UserId = Convert.ToInt32(Request.Cookies["id"]);
         
            CategoryManager category = new CategoryManager(_httpClientFactory);
            var result = category.DeleteCategory(parameter);

            return Content(result.Result);
        }

        public IActionResult AddCategory([FromBody] Category parameter)
        {
            parameter.UserId = Convert.ToInt32(Request.Cookies["id"]);
        
            CategoryManager category = new CategoryManager(_httpClientFactory);
            var result = category.AddCategory(parameter);

            return Content(result.Result);
        }

        public IActionResult UpdateCategory([FromBody] Category parameter)
        {
            parameter.UserId = Convert.ToInt32(Request.Cookies["id"]);
        
            CategoryManager category = new CategoryManager(_httpClientFactory);
            var result = category.UpdateCategory(parameter);

            return Content(result.Result);
        }
    }
}
