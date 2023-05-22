using Microsoft.AspNetCore.Mvc;
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

        [HttpPost("AddStatu")]
        public IActionResult AddStatu(Tasks parameter)
        {
            TaskCallManager task = new TaskCallManager();
            var result = task.AddStatu(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("GetTaskByCompanyRefId")]
        public IActionResult GetTaskByCompanyRefId(ReferansParameter parameter)
        {
            TaskCallManager task = new TaskCallManager();
            var result = task.GetTaskByCompanyRefId(parameter);
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
