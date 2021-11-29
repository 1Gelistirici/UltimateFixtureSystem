using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using UltimateAPI.Entities;
using UltimateDemerbas.Manager;

namespace UltimateDemerbas.Controllers
{
    public class LicensesTypesController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public LicensesTypesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Test()
        {
            return View();
        }

        public IActionResult GetLicensesType([FromBody] LicensesType parameter)
        {
            LicensesTypeManager licensesTypeManager = new LicensesTypeManager(_httpClientFactory);
            var result = licensesTypeManager.GetLicensesType(parameter);

            return Content(result.Result);
        }

        public IActionResult DeleteLicensesTypes([FromBody] LicensesType parameter)
        {
            parameter.UserId = Convert.ToInt32(Request.Cookies["id"]);

            LicensesTypeManager licensesTypeManager = new LicensesTypeManager(_httpClientFactory);
            var result = licensesTypeManager.DeleteLicensesType(parameter);

            return Content(result.Result);
        }

        public IActionResult GetLicensesTypes()
        {
            LicensesTypeManager licensesTypeManager = new LicensesTypeManager(_httpClientFactory);
            var result = licensesTypeManager.GetLicensesTypes();

            return Content(result.Result);
        }

        public IActionResult AddLicenseType([FromBody] LicensesType data)
        {
            data.UserId = Convert.ToInt32(Request.Cookies["id"]);

            LicensesTypeManager licensesTypeManager = new LicensesTypeManager(_httpClientFactory);
            var result = licensesTypeManager.AddLicenseType(data);

            return Content(result.Result);
        }

        public IActionResult UpdateLicenseType([FromBody] LicensesType data)
        {
            data.UserId = Convert.ToInt32(Request.Cookies["id"]);

            LicensesTypeManager licensesTypeManager = new LicensesTypeManager(_httpClientFactory);
            var result = licensesTypeManager.UpdateLicenseType(data);

            return Content(result.Result);
        }

    }
}
