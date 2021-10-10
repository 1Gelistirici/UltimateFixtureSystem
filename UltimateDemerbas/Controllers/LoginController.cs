﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using UltimateDemerbas.Entities;
using UltimateDemerbas.Manager;

namespace UltimateDemerbas.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public LoginController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Authenticate([FromBody] User user)
        {
            user.UserId = Convert.ToInt32(Request.Cookies["id"]);

            LoginManager login = new LoginManager(_httpClientFactory);
            var result = login.Authenticate(user);

            return Content(result.Result);
        }











    }
}
