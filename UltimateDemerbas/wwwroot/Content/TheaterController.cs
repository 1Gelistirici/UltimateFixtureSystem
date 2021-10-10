using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Content
{
    public class TheaterController : Controller
    {
        // GET: Theater
        public ActionResult Index()
        {
            return View();
        }
    }
}