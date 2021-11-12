using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using UltimateAPI.Entities;
using UltimateDemerbas.Manager;

namespace UltimateDemerbas.Controllers
{
    public class AssignmentController : BaseController
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AssignmentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAssignments()
        {
            Assignment parameter = new Assignment();
            parameter.UserId = WorkingUser;

            AssignmentManager componentModel = new AssignmentManager(_httpClientFactory);
            var result = componentModel.GetAssignments();

            return Content(result.Result);
        }
       
        public IActionResult DeleteAssignment([FromBody] Assignment parameter)
        {
            AssignmentManager componentModel = new AssignmentManager(_httpClientFactory);
            var result = componentModel.DeleteAssignment(parameter);

            return Content(result.Result);
        }

        public IActionResult AddAssignment([FromBody] Assignment parameter)
        {
            parameter.AppointerId = WorkingUser;

            AssignmentManager componentModel = new AssignmentManager(_httpClientFactory);
            var result = componentModel.AddAssignment(parameter);

            return Content(result.Result);
        }

        public IActionResult UpdateAssignment([FromBody] Assignment parameter)
        {
            AssignmentManager componentModel = new AssignmentManager(_httpClientFactory);
            var result = componentModel.UpdateAssignment(parameter);

            return Content(result.Result);
        }

        public IActionResult GetAssignmentUser()
        {
            Assignment parameter = new Assignment();
            parameter.UserId = WorkingUser;

            AssignmentManager componentModel = new AssignmentManager(_httpClientFactory);
            var result = componentModel.GetAssignmentUser(parameter);

            return Content(result.Result);
        }

    }
}
