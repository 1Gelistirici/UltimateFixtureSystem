using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using UltimateAPI.Entities;
using UltimateDemerbas.Manager;

namespace UltimateDemerbas.Controllers
{
    public class FixLicController : BaseController
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public FixLicController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult AddFixLic([FromBody] FixLic parameter)
        {
            FixLicManager fixture = new FixLicManager(_httpClientFactory);
            var result = fixture.AddFixLic(parameter);

            return Content(result.Result);
        }

        public IActionResult GetFixLices()
        {
            FixLic parameter = new FixLic();
            parameter.CompanyId = 1; // ToDo : WorkingCompany'den alınacak
            FixLicManager fixture = new FixLicManager(_httpClientFactory);
            var result = fixture.GetFixLices(parameter);

            return Content(result.Result);
        }

        public IActionResult DeleteFixLic([FromBody] FixLic parameter)
        {
            FixLicManager fixture = new FixLicManager(_httpClientFactory);
            var result = fixture.DeleteFixLic(parameter);

            return Content(result.Result);
        }

    }
}
