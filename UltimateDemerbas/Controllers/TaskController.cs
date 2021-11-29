using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using UltimateAPI.Entities;
using UltimateDemerbas.Manager;

namespace UltimateDemerbas.Controllers
{
    public class TaskController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public TaskController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult GetTask([FromBody] Tasks parameter)
        {
            TaskManager task = new TaskManager(_httpClientFactory);
            var result = task.GetTask(parameter);

            return Content(result.Result);
        }
        
        public IActionResult GetTasks()
        {
            Tasks parameter = new Tasks();
            parameter.UserId = Convert.ToInt32(Request.Cookies["id"]);

            TaskManager task = new TaskManager(_httpClientFactory);
            var result = task.GetTasks(parameter);

            return Content(result.Result);
        }

        public IActionResult DeleteTask([FromBody] Tasks parameter)
        {
            parameter.UserId = Convert.ToInt32(Request.Cookies["id"]);
            
            TaskManager task = new TaskManager(_httpClientFactory);
            var result = task.DeleteTask(parameter);

            return Content(result.Result);
        }
        
        public IActionResult UpdateTask([FromBody] Tasks parameter)
        {
            parameter.UserId = Convert.ToInt32(Request.Cookies["id"]);
         
            TaskManager task = new TaskManager(_httpClientFactory);
            var result = task.UpdateTask(parameter);

            return Content(result.Result);
        }

        public IActionResult AddTask([FromBody] Tasks parameter)
        {
            parameter.UserId = Convert.ToInt32(Request.Cookies["id"]);
          
            TaskManager task = new TaskManager(_httpClientFactory);
            var result = task.AddTask(parameter);

            return Content(result.Result);
        }

    }
}
