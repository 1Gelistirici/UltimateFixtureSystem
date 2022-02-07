using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UltimateDemerbas.Controllers
{
    public class ErrorController : BaseController
    {
        protected override int PageNumber { get; set; } = 0;
      
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
