using Microsoft.AspNetCore.Mvc;
using UltimateAPI.CallManager;
using UltimateAPI.Entities;

namespace UltimateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {

        [HttpGet("GetCompanies")]
        public IActionResult GetCompanies()
        {
            var result = CompanyCallManager.Instance.GetCompanies();
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("GetCompanyGroup")]
        public IActionResult GetCompanyGroup(ReferansParameter parameter)
        {
            var result = CompanyCallManager.Instance.GetCompanyGroup(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("GetCompany")]
        public IActionResult GetCompany(ReferansParameter parameter)
        {
            var result = CompanyCallManager.Instance.GetCompany(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        [HttpPost("DeleteCompany")]
        public IActionResult DeleteCompany(ReferansParameter parameter)
        {
            var result = CompanyCallManager.Instance.DeleteCompany(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, null));
        }

        [HttpPost("AddCompany")]
        public IActionResult AddCompany(Company parameter)
        {
            var result = CompanyCallManager.Instance.AddCompany(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, null));
        }

        [HttpPost("UpdateCompany")]
        public IActionResult UpdateCompany(Company parameter)
        {
            var result = CompanyCallManager.Instance.UpdateCompany(parameter);
            return Content(ResultData.Get(result.IsSuccess, result.Message, null));
        }

    }
}
