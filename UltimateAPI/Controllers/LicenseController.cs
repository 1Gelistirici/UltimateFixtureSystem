using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UltimateAPI.CallManager;
using UltimateAPI.Entities;

namespace UltimateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicenseController : ControllerBase
    {

        [HttpPost("AddLicense")]
        public IActionResult AddLicense(License parameter)
        {
            LicenseCallManager license = new LicenseCallManager();
            var result = license.AddLicense(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpGet("GetLicenses")]
        public IActionResult GetLicenses()
        {
            LicenseCallManager license = new LicenseCallManager();
            var result = license.GetLicenses();
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("DeleteLicense")]
        public IActionResult DeleteLicense(License parameter)
        {
            LicenseCallManager license = new LicenseCallManager();
            var result = license.DeleteLicense(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("UpdateLicense")]
        public IActionResult UpdateSituation(License parameter)
        {
            LicenseCallManager license = new LicenseCallManager();
            var result = license.UpdateLicense(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

    }
}
