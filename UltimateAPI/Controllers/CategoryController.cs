using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UltimateAPI.CallManager;
using UltimateAPI.Entities;

namespace UltimateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpPost("AddCategory")]
        public IActionResult AddCategory(Category parameter)
        {
            CategoryCallManager category = new CategoryCallManager();
            var result = category.AddCategory(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpGet("GetCategories")]
        public IActionResult GetCategories()
        {
            CategoryCallManager category = new CategoryCallManager();
            var result = category.GetCategories();
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("DeleteCategory")]
        public IActionResult DeleteCategory(Category parameter)
        {
            CategoryCallManager category = new CategoryCallManager();
            var result = category.DeleteCategory(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("UpdateCategory")]
        public IActionResult UpdateCategory(Category parameter)
        {
            CategoryCallManager category = new CategoryCallManager();
            var result = category.UpdateCategory(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }
    }
}
