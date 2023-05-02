using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using UltimateAPI.Entities;
using UltimateDemerbas.Manager;
using UltimateDemerbas.Models.Tool;

namespace UltimateDemerbas.Controllers
{
    [CheckAuthorize]
    public class CompanyController : BaseController
    {
        protected override int PageNumber { get; set; } = 60;
        public IActionResult Index()
        {
            return View();
        }
    }
}
