﻿using Microsoft.AspNetCore.Mvc;

namespace UltimateDemerbas.Controllers
{
    public class ProfileController : BaseController
    {
        protected override int PageNumber { get; set; } = 0;
      
        public IActionResult Index()
        {
            return View();
        }
    }
}
