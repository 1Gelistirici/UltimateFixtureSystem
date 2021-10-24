using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using UltimateAPI.Entities;
using UltimateDemerbas.Entities;
using UltimateDemerbas.Manager;

namespace UltimateDemerbas.Controllers
{
    public class AssignmentController : Controller
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

        public IActionResult GetComponentModels()
        {
            Assignment parameter = new Assignment();
            parameter.UserId = Convert.ToInt32(Request.Cookies["id"]);

            AssignmentManager componentModel = new AssignmentManager(_httpClientFactory);
            var result = componentModel.GetAssignments();

            return Content(result.Result);
        }

        public IActionResult DeleteComponentModel([FromBody] Assignment parameter)
        {
            AssignmentManager componentModel = new AssignmentManager(_httpClientFactory);
            var result = componentModel.DeleteAssignment(parameter);

            return Content(result.Result);
        }

        public IActionResult AddComponentModel([FromBody] Assignment parameter)
        {
            AssignmentManager componentModel = new AssignmentManager(_httpClientFactory);
            var result = componentModel.AddAssignment(parameter);

            return Content(result.Result);
        }

        public IActionResult UpdateComponentModel([FromBody] Assignment parameter)
        {
            AssignmentManager componentModel = new AssignmentManager(_httpClientFactory);
            var result = componentModel.UpdateAssignment(parameter);

            return Content(result.Result);
        }
    }
}
