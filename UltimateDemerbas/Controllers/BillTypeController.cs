using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using UltimateAPI.Entities;
using UltimateDemerbas.Manager;
using UltimateDemerbas.Models.Tool;

namespace UltimateDemerbas.Controllers
{
    [CheckAuthorize]
    public class BillTypeController : BaseController
    {
        protected override int PageNumber { get; set; } = 33;
        private readonly IHttpClientFactory _httpClientFactory;
        BillTypeManager billType;
        public BillTypeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            billType = new BillTypeManager(_httpClientFactory);
        }


        [CheckAuthorize]
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult GetBillTypes()
        {
            BillTypeManager billType = new BillTypeManager(_httpClientFactory);
            var result = billType.GetBillTypes();

            return Content(result.Result);
        }

        public IActionResult DeleteBillType([FromBody] BillType parameter)
        {
            parameter.UserId = WorkingUser;
            var result = billType.DeleteBillType(parameter);
            return Content(result.Result);
        }

        public IActionResult AddBillType([FromBody] BillType parameter)
        {
            parameter.UserId = WorkingUser;
            var result = billType.AddBillType(parameter);
            return Content(result.Result);
        }

        public IActionResult UpdateBillType([FromBody] BillType parameter)
        {
            parameter.UserId = WorkingUser;
            var result = billType.UpdateBillType(parameter);
            return Content(result.Result);
        }

        public IActionResult GetBillTypeByCompanyRefId()
        {
            var result = billType.GetBillTypeByCompanyRefId(new ReferansParameter() { RefId = WorkingCompany });
            return Content(result.Result);
        }
    }
}
