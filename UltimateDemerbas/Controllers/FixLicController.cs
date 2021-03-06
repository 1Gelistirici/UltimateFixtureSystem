using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using UltimateAPI.Entities;
using UltimateDemerbas.Manager;
using UltimateDemerbas.Models.Tool;

namespace UltimateDemerbas.Controllers
{
    [CheckAuthorize]
    public class FixLicController : BaseController
    {
        protected override int PageNumber { get; set; } = 0;
        private readonly IHttpClientFactory _httpClientFactory;
        FixLicManager fixture;
        public FixLicController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            fixture = new FixLicManager(_httpClientFactory);
        }


        [CheckAuthorize]
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult AddFixLic([FromBody] FixLic parameter)
        {
            var result = fixture.AddFixLic(parameter);
            return Content(result.Result);
        }

        public IActionResult GetFixLices()
        {
            FixLic parameter = new FixLic();
            parameter.CompanyId = WorkingCompany;
            var result = fixture.GetFixLices(parameter);

            return Content(result.Result);
        }

        public IActionResult DeleteFixLic([FromBody] FixLic parameter)
        {
            var result = fixture.DeleteFixLic(parameter);
            return Content(result.Result);
        }

    }
}
