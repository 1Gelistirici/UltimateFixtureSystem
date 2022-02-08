using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using UltimateAPI.Entities;
using UltimateDemerbas.Manager;

namespace UltimateDemerbas.Controllers
{
    public class TaskController : BaseController
    {
        protected override int PageNumber { get; set; } = 0;
        private readonly IHttpClientFactory _httpClientFactory;
        TaskManager task;
        public TaskController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            task = new TaskManager(_httpClientFactory);
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult GetTask([FromBody] Tasks parameter)
        {
            var result = task.GetTask(parameter);

            return Content(result.Result);
        }

        public IActionResult GetTasks()
        {
            Tasks parameter = new Tasks();
            parameter.UserId = WorkingUser;

            var result = task.GetTasks(parameter);

            return Content(result.Result);
        }

        public IActionResult DeleteTask([FromBody] Tasks parameter)
        {
            parameter.UserId = WorkingUser;

            var result = task.DeleteTask(parameter);

            return Content(result.Result);
        }

        public IActionResult UpdateTask([FromBody] Tasks parameter)
        {
            parameter.UserId = WorkingUser;

            var result = task.UpdateTask(parameter);

            return Content(result.Result);
        }

        public IActionResult AddTask([FromBody] Tasks parameter)
        {
            parameter.UserId = WorkingUser;

            var result = task.AddTask(parameter);

            return Content(result.Result);
        }

    }
}
