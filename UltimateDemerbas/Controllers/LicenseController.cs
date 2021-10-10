using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using UltimateDemerbas.Entities;
using UltimateDemerbas.Manager;

namespace UltimateDemerbas.Controllers
{
    public class LicenseController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public LicenseController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult GetLicenses()
        {
            LicenseManager license = new LicenseManager(_httpClientFactory);
            var result = license.GetLicenses();

            return Content(result.Result);
        }

        public IActionResult DeleteLicense([FromBody] License parameter)
        {
            parameter.UserId = Convert.ToInt32(Request.Cookies["id"]);
         
            LicenseManager licensManager = new LicenseManager(_httpClientFactory);
            var result = licensManager.DeleteLicense(parameter);

            return Content(result.Result);
        }

        public IActionResult UpdateLicense([FromBody] License data)
        {
            data.UserId = Convert.ToInt32(Request.Cookies["id"]);
          
            LicenseManager licensManager = new LicenseManager(_httpClientFactory);
            var result = licensManager.UpdateLicense(data);

            return Content(result.Result);
        }
        
        public IActionResult AddLicense([FromBody] License data)
        {
            data.UserId = Convert.ToInt32(Request.Cookies["id"]);

            LicenseManager licensManager = new LicenseManager(_httpClientFactory);
            var result = licensManager.AddLicense(data);

            return Content(result.Result);
        }
    }
}
