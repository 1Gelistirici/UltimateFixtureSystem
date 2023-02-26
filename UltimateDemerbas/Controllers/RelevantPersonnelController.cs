using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using UltimateAPI.Entities;
using UltimateDemerbas.Manager;
using UltimateDemerbas.Models.Tool;

namespace UltimateDemerbas.Controllers
{
    [CheckAuthorize]
    public class RelevantPersonnelController : BaseController
    {
        protected override int PageNumber { get; set; } = 45;
        private readonly IHttpClientFactory _httpClientFactory;
        RelevantPersonnelManager reveland;
        public RelevantPersonnelController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            reveland = new RelevantPersonnelManager(_httpClientFactory);
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult GetRelevantPersonnels()
        {
            var result = reveland.GetRelevantPersonnels(new ReferansParameter { CompanyId = WorkingCompany });
            return Content(result.Result);
        }

        public IActionResult DeleteRelevantPersonnel([FromBody]  ReferansParameter parameter)
        {
            var result = reveland.DeleteRelevantPersonnel(parameter);
            return Content(result.Result);
        }

        public IActionResult AddRelevantPersonnel([FromBody] RelevantPersonnel parameter)
        {
            parameter.CompanyRefId = WorkingCompany;
            var result = reveland.AddRelevantPersonnel(parameter);
            return Content(result.Result);
        }
    }
}
