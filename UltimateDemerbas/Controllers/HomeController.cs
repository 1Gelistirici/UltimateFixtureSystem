using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UltimateDemerbas.Models;
using UltimateDemerbas.Models.Tool;

namespace UltimateDemerbas.Controllers
{
    [CheckAuthorize]
    public class HomeController : BaseController
    {
        protected override int PageNumber { get; set; } = 0;


        [CheckAuthorize]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
