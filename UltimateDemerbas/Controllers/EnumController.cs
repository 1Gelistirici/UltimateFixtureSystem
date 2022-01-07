using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using UltimateDemerbas.Manager;

namespace UltimateDemerbas.Controllers
{
    public class EnumController : BaseController
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public EnumController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public IActionResult GetIsActiveTypes()
        {
            var toner = new EnumManager(_httpClientFactory);
            var result = toner.GetIsActiveTypes();

            return Content(result.Result);
        }

    }
}
