using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using UltimateAPI.Entities;
using UltimateDemerbas.Manager;
using UltimateDemerbas.Models.Tool;

namespace UltimateDemerbas.Controllers
{
    [CheckAuthorize]
    public class LicensesTypesController : BaseController
    {
        protected override int PageNumber { get; set; } = 42;
        private readonly IHttpClientFactory _httpClientFactory;
        LicensesTypeManager licensesTypeManager;
        public LicensesTypesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            licensesTypeManager = new LicensesTypeManager(_httpClientFactory);
        }


        [CheckAuthorize]
        public IActionResult Index()
        {
            return View();
        }

        [CheckAuthorize]
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
            parameter.UserId = WorkingUser;

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
            data.UserId = WorkingUser;

            var result = licensesTypeManager.AddLicenseType(data);

            return Content(result.Result);
        }

        public IActionResult UpdateLicenseType([FromBody] LicensesType data)
        {
            data.UserId = WorkingUser;

            var result = licensesTypeManager.UpdateLicenseType(data);

            return Content(result.Result);
        }
    }
}
