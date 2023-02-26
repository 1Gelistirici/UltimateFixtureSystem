using Microsoft.AspNetCore.Mvc;
using UltimateDemerbas.Models.Tool;

namespace UltimateDemerbas.Controllers
{
    public class ErrorController : BaseController
    {
        protected override int PageNumber { get; set; } = 0;
      
        //[Authorize]
        [CheckAuthorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
