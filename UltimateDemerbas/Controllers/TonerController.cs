using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using UltimateAPI.Entities;
using UltimateDemerbas.Manager;
using UltimateDemerbas.Models.Tool;

namespace UltimateDemerbas.Controllers
{
    [CheckAuthorize]
    public class TonerController : BaseController
    {
        protected override int PageNumber { get; set; } = 50;
        private readonly IHttpClientFactory _httpClientFactory;
        TonerManager toner;
        public TonerController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            toner = new TonerManager(_httpClientFactory);
        }

        [CheckAuthorize]
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult GetToners()
        {
            var result = toner.GetToners();
            return Content(result.Result);
        }

        public IActionResult DeleteToner([FromBody] Toner parameter)
        {
            parameter.UserId = WorkingUser;

            var result = toner.DeleteToner(parameter);
            return Content(result.Result);
        }

        public IActionResult AddToner([FromBody] Toner parameter)
        {
            parameter.UserId = WorkingUser;

            var result = toner.AddToner(parameter);
            return Content(result.Result);
        }

        public IActionResult UpdateToner([FromBody] Toner parameter)
        {
            parameter.UserId = WorkingUser;

            var result = toner.UpdateToner(parameter);
            return Content(result.Result);
        }

        public IActionResult GetTonerByCompanyRefId()
        {
            var result = toner.GetTonerByCompanyRefId(new ReferansParameter() { RefId = WorkingCompany });
            return Content(result.Result);
        }


        //public IActionResult GetToner([FromBody] Login login)
        //{
        //    TonerManager tonerManager = new TonerManager(_httpClientFactory);
        //    var result = tonerManager.GetToner(login);

        //    return Content(result.Result);
        //}

        //public IActionResult GetToners()
        //{
        //    TonerManager tonerManager = new TonerManager(_httpClientFactory);
        //    var result = tonerManager.GetToners();

        //    return Content(result.Result);
        //}

    }
}
