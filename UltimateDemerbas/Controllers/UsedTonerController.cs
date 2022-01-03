using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using UltimateAPI.Entities;
using UltimateDemerbas.Manager;

namespace UltimateDemerbas.Controllers
{
    public class UsedTonerController : BaseController
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public UsedTonerController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetUsedToners()
        {
            UsedTonerManager usedToner = new UsedTonerManager(_httpClientFactory);
            var result = usedToner.GetUsedToners();

            return Content(result.Result);
        }

        public IActionResult GetUsedToner()
        {
            UsedToner parameter = new UsedToner();
            parameter.CompanyId = 1; // ToDO : WorkingCompany'den alıncaktır

            UsedTonerManager usedToner = new UsedTonerManager(_httpClientFactory);
            var result = usedToner.GetUsedToner(parameter);

            return Content(result.Result);
        }

        public IActionResult AddUsedToner([FromBody] UsedToner parameter)
        {
            UsedTonerManager usedToner = new UsedTonerManager(_httpClientFactory);
            var result = usedToner.AddUsedToner(parameter);

            return Content(result.Result);
        }

        public IActionResult UpdateUsedToner([FromBody] UsedToner parameter)
        {
            UsedTonerManager usedToner = new UsedTonerManager(_httpClientFactory);
            var result = usedToner.UpdateUsedToner(parameter);

            return Content(result.Result);
        }

        public IActionResult DeleteUsedToner([FromBody] UsedToner parameter)
        {
            UsedTonerManager usedToner = new UsedTonerManager(_httpClientFactory);
            var result = usedToner.DeleteUsedToner(parameter);

            return Content(result.Result);
        }
    }
}
