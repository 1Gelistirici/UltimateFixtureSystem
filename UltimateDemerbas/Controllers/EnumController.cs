using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using UltimateDemerbas.Manager;

namespace UltimateDemerbas.Controllers
{
    public class EnumController : BaseController
    {
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

    }
}
