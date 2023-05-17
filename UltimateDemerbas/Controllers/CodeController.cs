using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using UltimateAPI.Entities;
using UltimateDemerbas.Manager;

namespace UltimateDemerbas.Controllers
{
    public class CodeController : BaseController
    {
        protected override int PageNumber { get; set; } = 0;
        private readonly IHttpClientFactory _httpClientFactory;
        CodeManager codeManager;
        public CodeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            codeManager = new CodeManager(_httpClientFactory);
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetCode([FromBody] Code parameter)
        {
            var result = codeManager.GetCode(parameter);
            return Content(result.Result);
        }

        public IActionResult GetCodeV1([FromBody] Code parameter)
        {
            var result = codeManager.GetCodeV1(parameter);
            return Content(result.Result);
        }

        public IActionResult AddCode([FromBody] Code parameter)
        {
            var result = codeManager.AddCode(parameter);
            return Content(result.Result);
        }
    }
}
