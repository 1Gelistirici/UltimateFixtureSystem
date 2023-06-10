using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using UltimateDemerbas.Models;
using UltimateDemerbas.Models.Tool;

namespace UltimateDemerbas.Controllers
{
    [CheckAuthorize]
    public class HomeController : BaseController
    {
        protected override int PageNumber { get; set; } = 21;


        [CheckAuthorize]
        public IActionResult Index()
        {
            return View();
        }

        [CheckAuthorize]
        public IActionResult PageMap()
        {
            return View();
        }

        [CheckAuthorize]
        public IActionResult InfoPage()
        {
            return View();
        }

        [CheckAuthorize]
        public IActionResult ViewItemQR()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(30) }
            );

            return Redirect(returnUrl);
        }

    }
}
