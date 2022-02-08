using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using UltimateAPI.Entities;
using UltimateDemerbas.Manager;

namespace UltimateDemerbas.Controllers
{
    public class DepartmentController : BaseController
    {
        protected override int PageNumber { get; set; } = 1;
        private readonly IHttpClientFactory _httpClientFactory;
        DepartmentManager department;
        public DepartmentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            department = new DepartmentManager(_httpClientFactory);
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetDepartments()
        {
            Department parameter = new Department();
            parameter.CompanyId = 1; // ToDO : WorkingCompany'den alıncaktır

            var result = department.GetDepartments(parameter);
            return Content(result.Result);
        }

        public IActionResult AddDepartment([FromBody] Department parameter)
        {
            parameter.CompanyId = 1; // ToDo : WorkingCompany'den çekilecek

            var result = department.AddDepartment(parameter);
            return Content(result.Result);
        }

        public IActionResult UpdateDepartment([FromBody] Department parameter)
        {
            var result = department.UpdateDepartment(parameter);
            return Content(result.Result);
        }

        public IActionResult DeleteDepartment([FromBody] Department parameter)
        {
            var result = department.DeleteDepartment(parameter);
            return Content(result.Result);
        }
    }
}
