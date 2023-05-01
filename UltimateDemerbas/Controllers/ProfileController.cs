using Microsoft.AspNetCore.Mvc;
using UltimateDemerbas.Models.Tool;

namespace UltimateDemerbas.Controllers
{
    [CheckAuthorize]
    public class ProfileController : BaseController
    {
        protected override int PageNumber { get; set; } = 0;
      
        [CheckAuthorize]
        public IActionResult Index()
        {
            return View();
        }
      
        [CheckAuthorize]
        public IActionResult DepozitFormPage()
        {
            return View();
        }
    }
}
