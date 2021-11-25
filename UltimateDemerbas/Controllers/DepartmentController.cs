using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using UltimateAPI.Entities;
using UltimateDemerbas.Manager;

namespace UltimateDemerbas.Controllers
{
    public class DepartmentController : BaseController
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public DepartmentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetDepartments()
        {
            Department parameter = new Department();
            parameter.UserId = WorkingUser;

            DepartmentManager department = new DepartmentManager(_httpClientFactory);
            var result = department.GetDepartments(parameter);

            return Content(result.Result);
        }

    }
}
