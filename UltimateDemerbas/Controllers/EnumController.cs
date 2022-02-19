using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using UltimateDemerbas.Manager;
using UltimateDemerbas.Models.Tool;

namespace UltimateDemerbas.Controllers
{
    [CheckAuthorize]
    public class EnumController : BaseController
    {
        protected override int PageNumber { get; set; } = 1;
        private readonly IHttpClientFactory _httpClientFactory;
        EnumManager enumManager;
        public EnumController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            enumManager = new EnumManager(_httpClientFactory);
        }


        public IActionResult GetIsActiveTypes()
        {
            var result = enumManager.GetIsActiveTypes();
            return Content(result.Result);
        }

        public IActionResult GetItemStatuTypes()
        {
            var result = enumManager.GetItemStatuTypes();
            return Content(result.Result);
        }

        public IActionResult GetItemTypeTypes()
        {
            var result = enumManager.GetItemTypeTypes();
            return Content(result.Result);
        }

        public IActionResult GetReportStatus()
        {
            var result = enumManager.GetReportStatus();
            return Content(result.Result);
        }

        public IActionResult GetProductTypes()
        {
            var result = enumManager.GetProductTypes();
            return Content(result.Result);
        }

        public IActionResult GetDepartments()
        {
            var result = enumManager.GetDepartments();
            return Content(result.Result);
        }

        public IActionResult GetGenders()
        {
            var result = enumManager.GetGenders();
            return Content(result.Result);
        }
    }
}
