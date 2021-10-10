using Microsoft.AspNetCore.Mvc;
using UltimateAPI.CallManager;
using UltimateAPI.Entities;

namespace UltimateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicanseTypeController : ControllerBase
    {

        [HttpGet("GetLicensesTypes")]
        public IActionResult GetLicensesTypes()
        {
            LicenseTypesCallManager licenseTypes = new LicenseTypesCallManager();
            var result = licenseTypes.GetLicensesTypes();
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("GetLicensesType")]
        public IActionResult GetLicensesType(LicensesType parameter)
        {
            LicenseTypesCallManager licenseTypes = new LicenseTypesCallManager();
            var result = licenseTypes.GetLicensesType(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }
        
        [HttpPost("DeleteLicensesType")]
        public IActionResult DeleteLicensesType(LicensesType parameter)
        {
            LicenseTypesCallManager licenseTypes = new LicenseTypesCallManager();
            var result = licenseTypes.DeleteLicensesType(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("AddLicenseType")]
        public IActionResult AddLicenseType(LicensesType parameter)
        {
            LicenseTypesCallManager licenseTypes = new LicenseTypesCallManager();
            var result = licenseTypes.AddLicensesType(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }
                
        [HttpPost("UpdateLicenseType")]
        public IActionResult UpdateLicenseType(LicensesType parameter)
        {
            LicenseTypesCallManager licenseTypes = new LicenseTypesCallManager();
            var result = licenseTypes.UpdateLicenseType(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }








        //[HttpPost("DeleteLicensesType")]
        //public IActionResult DeleteLicensesType(LicensesType parameter)
        //{
        //    LicenseTypesCallManager licenseTypes = new LicenseTypesCallManager();
        //    var result = licenseTypes.DeleteLicensesType(parameter);
        //    return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        //}

        //[HttpPost("DeleteLicensesType")]
        //public IActionResult AddLicensesType(LicensesType parameter)
        //{
        //    LicenseTypesCallManager licenseTypes = new LicenseTypesCallManager();
        //    var result = licenseTypes.AddLicensesType(parameter);
        //    return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        //}

        //[HttpPost("DeleteLicensesType")]
        //public IActionResult UpdateLicensesType(LicensesType parameter)
        //{
        //    LicenseTypesCallManager licenseTypes = new LicenseTypesCallManager();
        //    var result = licenseTypes.UpdateLicensesType(parameter);
        //    return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        //}



    }
}
