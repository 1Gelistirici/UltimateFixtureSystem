using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using UltimateAPI.Entities;
using UltimateDemerbas.Manager;
using UltimateDemerbas.Models.Tool;

namespace UltimateDemerbas.Controllers
{
    public class CodeController : BaseController
    {
        protected override int PageNumber { get; set; } = 0;
        private readonly IHttpClientFactory _httpClientFactory;
        CodeController category;
        public CodeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            category = new CodeController(_httpClientFactory);
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
            parameter.UserId = WorkingUser;
            var result = category.DeleteCategory(parameter);
            return Content(result.Result);
        }

        public IActionResult AddCategory([FromBody] Category parameter)
        {
            parameter.UserId = WorkingUser;
            var result = category.AddCategory(parameter);
            return Content(result.Result);
        }
    }
}
