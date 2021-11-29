using Microsoft.AspNetCore.Mvc;

namespace UltimateDemerbas.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
