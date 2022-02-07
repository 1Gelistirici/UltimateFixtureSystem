using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using UltimateAPI.Entities;
using UltimateDemerbas.Manager;

namespace UltimateDemerbas.Controllers
{
    public class LicensesTypesController : BaseController
    {
        protected override int PageNumber { get; set; } = 0;
        private readonly IHttpClientFactory _httpClientFactory;
        LicensesTypeManager licensesTypeManager;
        public LicensesTypesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            licensesTypeManager = new LicensesTypeManager(_httpClientFactory);
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
            var result = licensesTypeManager.GetLicensesType(parameter);

            return Content(result.Result);
        }

        public IActionResult DeleteLicensesTypes([FromBody] LicensesType parameter)
        {
            parameter.UserId = Convert.ToInt32(Request.Cookies["id"]);

            var result = licensesTypeManager.DeleteLicensesType(parameter);

            return Content(result.Result);
        }

        public IActionResult GetLicensesTypes()
        {
            var result = licensesTypeManager.GetLicensesTypes();

            return Content(result.Result);
        }

        public IActionResult AddLicenseType([FromBody] LicensesType data)
        {
            data.UserId = Convert.ToInt32(Request.Cookies["id"]);

            var result = licensesTypeManager.AddLicenseType(data);

            return Content(result.Result);
        }

        public IActionResult UpdateLicenseType([FromBody] LicensesType data)
        {
            data.UserId = Convert.ToInt32(Request.Cookies["id"]);

            var result = licensesTypeManager.UpdateLicenseType(data);

            return Content(result.Result);
        }
    }
}
