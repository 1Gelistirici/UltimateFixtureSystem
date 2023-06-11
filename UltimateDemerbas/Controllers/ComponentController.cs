using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using UltimateAPI.Entities;
using UltimateDemerbas.Manager;
using UltimateDemerbas.Models.Tool;

namespace UltimateDemerbas.Controllers
{
    [CheckAuthorize]
    public class ComponentController : BaseController
    {
        protected override int PageNumber { get; set; } = 34;
        private readonly IHttpClientFactory _httpClientFactory;
        ComponentManager component;
        public ComponentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            component = new ComponentManager(_httpClientFactory);
        }


        [CheckAuthorize]
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult GetComponents()
        {
            var result = component.GetComponents();
            return Content(result.Result);
        }

        public IActionResult GetComponents(int id)
        {
            var result = component.GetComponent(new ReferansParameter() { RefId = id });
            return Content(result.Result);
        }

        public IActionResult GetComponentByCompanyRefId()
        {
            var result = component.GetComponentByCompanyRefId(new ReferansParameter() { RefId = WorkingCompany });
            return Content(result.Result);
        }

        public IActionResult DeleteComponent([FromBody] Component parameter)
        {
            parameter.UserId = WorkingUser;
            var result = component.DeleteComponent(parameter);
            return Content(result.Result);
        }

        public IActionResult AddComponent([FromBody] Component parameter)
        {
            parameter.UserId = WorkingUser;
            var result = component.AddComponent(parameter);
            return Content(result.Result);
        }

        public IActionResult UpdateComponent([FromBody] Component parameter)
        {
            parameter.UserId = WorkingUser;
            var result = component.UpdateComponent(parameter);
            return Content(result.Result);
        }
    }
}
