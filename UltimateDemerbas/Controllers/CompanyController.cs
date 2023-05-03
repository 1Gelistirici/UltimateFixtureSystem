using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using UltimateAPI.Entities;
using UltimateDemerbas.Manager;
using UltimateDemerbas.Models.Tool;

namespace UltimateDemerbas.Controllers
{
    [CheckAuthorize]
    public class CompanyController : BaseController
    {
        protected override int PageNumber { get; set; } = 60;
        private readonly IHttpClientFactory _httpClientFactory;
        CompanyManager company;
        public CompanyController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            company = new CompanyManager(_httpClientFactory);
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult GetComponents()
        {
            var result = company.GetCompanies();
            return Content(result.Result);
        }

        public IActionResult GetCompanyGroup([FromBody] ReferansParameter parameter)
        {
            var result = company.GetCompanyGroup(parameter);
            return Content(result.Result);
        }

        public IActionResult GetCompany([FromBody] ReferansParameter parameter)
        {
            var result = company.GetCompany(parameter);
            return Content(result.Result);
        }

        public IActionResult DeleteCompany([FromBody] ReferansParameter parameter)
        {
            var result = company.DeleteCompany(parameter);
            return Content(result.Result);
        }

        public IActionResult AddCompany([FromBody] Company parameter)
        {
            var result = company.AddCompany(parameter);
            return Content(result.Result);
        }

        public IActionResult UpdateComponent([FromBody] Company parameter)
        {
            var result = company.UpdateCompany(parameter);
            return Content(result.Result);
        }

    }
}
