using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using UltimateAPI.Entities;
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


        public IActionResult GetToners()
        {
            EnumV toner = new TonerManager(_httpClientFactory);
            var result = toner.GetToners();

            return Content(result.Result);
        }

    }
}
