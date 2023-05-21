using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using UltimateAPI.Entities;
using UltimateDemerbas.Manager;
using UltimateDemerbas.Models.Tool;

namespace UltimateDemerbas.Controllers
{
    [CheckAuthorize]
    public class DepartmentController : BaseController
    {
        protected override int PageNumber { get; set; } = 36;
        private readonly IHttpClientFactory _httpClientFactory;
        DepartmentManager department;
        public DepartmentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            department = new DepartmentManager(_httpClientFactory);
        }

        [CheckAuthorize]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetDepartments()
        {
            Department parameter = new Department();
            parameter.CompanyId = WorkingCompany;

            var result = department.GetDepartments(parameter);
            return Content(result.Result);
        }

        public IActionResult GetDepartmentByCompanyRefId()
        {
            var result = department.GetDepartmentByCompanyRefId(new ReferansParameter() { RefId = WorkingCompany });
            return Content(result.Result);
        }

        public IActionResult AddDepartment([FromBody] Department parameter)
        {
            parameter.CompanyId = WorkingCompany;

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
