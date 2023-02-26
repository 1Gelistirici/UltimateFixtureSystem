using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using UltimateAPI.Entities;
using UltimateDemerbas.Manager;
using UltimateDemerbas.Models.Tool;

namespace UltimateDemerbas.Controllers
{
    [CheckAuthorize]
    public class AssignmentController : BaseController
    {
        protected override int PageNumber { get; set; } = 0;
        private readonly IHttpClientFactory _httpClientFactory;
        AssignmentManager assignment;
        public AssignmentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            assignment = new AssignmentManager(_httpClientFactory);
        }


        public IActionResult GetAssignments()
        {
            Assignment parameter = new Assignment();
            parameter.CompanyId = 1; // ToDo : WorkingCompany olacak
            var result = assignment.GetAssignments(parameter);
            return Content(result.Result);
        }

        public IActionResult DeleteAssignment([FromBody] Assignment parameter)
        {
            var result = assignment.DeleteAssignment(parameter);
            return Content(result.Result);
        }

        public IActionResult AddAssignment([FromBody] Assignment parameter)
        {
            parameter.AppointerId = WorkingUser;
            var result = assignment.AddAssignment(parameter);
            return Content(result.Result);
        }

        public IActionResult UpdateAssignment([FromBody] Assignment parameter)
        {
            var result = assignment.UpdateAssignment(parameter);
            return Content(result.Result);
        }

        public IActionResult GetAssignmentUser()
        {
            Assignment parameter = new Assignment();
            parameter.UserId = WorkingUser;
            var result = assignment.GetAssignmentUser(parameter);
            return Content(result.Result);
        }

    }
}
