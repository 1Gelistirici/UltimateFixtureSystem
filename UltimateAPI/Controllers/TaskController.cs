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
    public class TaskController : ControllerBase
    {
        [HttpPost("AddTask")]
        public IActionResult AddTask(Tasks parameter)
        {
            TaskCallManager task = new TaskCallManager();
            var result = task.AddTask(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("GetTasks")]
        public IActionResult GetTasks(Tasks parameter)
        {
            TaskCallManager task = new TaskCallManager();
            var result = task.GetTasks(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }
        
        [HttpPost("GetTask")]
        public IActionResult GetTask(Tasks parameter)
        {
            TaskCallManager task = new TaskCallManager();
            var result = task.GetTask(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("DeleteTask")]
        public IActionResult DeleteTask(Tasks parameter)
        {
            TaskCallManager task = new TaskCallManager();
            var result = task.DeleteTask(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }
        [HttpPost("UpdateTask")]
        public IActionResult UpdateTask(Tasks parameter)
        {
            TaskCallManager task = new TaskCallManager();
            var result = task.UpdateTask(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }
    }
}
