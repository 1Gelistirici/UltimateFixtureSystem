using Microsoft.AspNetCore.Mvc;

namespace UltimateDemerbas.Controllers
{
    public class DepreciationController : BaseController
    {
        protected override int PageNumber { get; set; } = 53;

        public IActionResult Index()
        {
            return View();
        }
    }
}
