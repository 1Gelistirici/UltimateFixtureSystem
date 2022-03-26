using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using UltimateAPI.Entities;
using UltimateDemerbas.Manager;
using UltimateDemerbas.Models.Tool;

namespace UltimateDemerbas.Controllers
{
    public class UserRoleController : BaseController
    {
        protected override int PageNumber { get; set; } = 0;
        private readonly IHttpClientFactory _httpClientFactory;
        UserRoleManager userRole;

        public UserRoleController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            userRole = new UserRoleManager(_httpClientFactory);
        }

        [CheckAuthorize]
        public IActionResult DeleteRole([FromBody] UserRole parameter)
        {
            var result = userRole.DeleteRole(parameter);
            return Content(result.Result);
        }

        [CheckAuthorize]
        public IActionResult AddRole([FromBody] UserRole parameter)
        {
            var result = userRole.AddRole(parameter);
            return Content(result.Result);
        }

        [CheckAuthorize]
        public IActionResult GetRole([FromBody] UserRole parameter)
        {
            var result = userRole.GetRole(parameter);
            return Content(result.Result);
        }

    }
}
