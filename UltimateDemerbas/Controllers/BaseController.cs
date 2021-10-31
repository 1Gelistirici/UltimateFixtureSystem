using Microsoft.AspNetCore.Mvc;
using System;

namespace UltimateDemerbas.Controllers
{
    public class BaseController : Controller
    {
        public int WorkingUser { get { return Convert.ToInt32(Request.Cookies["id"]); } }
    }
}
