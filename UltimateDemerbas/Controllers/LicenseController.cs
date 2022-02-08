using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using UltimateAPI.Entities;
using UltimateDemerbas.Manager;

namespace UltimateDemerbas.Controllers
{
    public class LicenseController : BaseController
    {
        protected override int PageNumber { get; set; } = 0;
        private readonly IHttpClientFactory _httpClientFactory;
        LicenseManager licence;
        public LicenseController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            licence = new LicenseManager(_httpClientFactory);
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult GetLicenses()
        {
            var result = licence.GetLicenses();
            return Content(result.Result);
        }

        public IActionResult DeleteLicense([FromBody] License parameter)
        {
            parameter.UserId = WorkingUser;

            var result = licence.DeleteLicense(parameter);

            return Content(result.Result);
        }

        public IActionResult UpdateLicense([FromBody] License data)
        {
            data.UserId = WorkingUser;

            var result = licence.UpdateLicense(data);

            return Content(result.Result);
        }

        public IActionResult AddLicense([FromBody] License data)
        {
            data.UserId = WorkingUser;

            var result = licence.AddLicense(data);

            return Content(result.Result);
        }
    }
}
