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
            parameter.CompanyId = 1; // ToDO : WorkingCompany'den alıncaktır

            DepartmentManager department = new DepartmentManager(_httpClientFactory);
            var result = department.GetDepartments(parameter);

            return Content(result.Result);
        }

        public IActionResult AddDepartment([FromBody] Department parameter)
        {
            parameter.CompanyId = 1; // ToDo : WorkingCompany'den çekilecek

            DepartmentManager department = new DepartmentManager(_httpClientFactory);
            var result = department.AddDepartment(parameter);

            return Content(result.Result);
        }

        public IActionResult UpdateDepartment([FromBody] Department parameter)
        {
            DepartmentManager department = new DepartmentManager(_httpClientFactory);
            var result = department.UpdateDepartment(parameter);

            return Content(result.Result);
        }

        public IActionResult DeleteDepartment([FromBody] Department parameter)
        {
            DepartmentManager department = new DepartmentManager(_httpClientFactory);
            var result = department.DeleteDepartment(parameter);

            return Content(result.Result);
        }
    }
}
