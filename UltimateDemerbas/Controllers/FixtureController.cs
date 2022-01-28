﻿using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using UltimateAPI.Entities;
using UltimateDemerbas.Manager;

namespace UltimateDemerbas.Controllers
{
    public class FixtureController : BaseController
    {
        private readonly IHttpClientFactory _httpClientFactory;
        FixtureManager fixture;
        public FixtureController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            fixture = new FixtureManager(_httpClientFactory);
        }


        public IActionResult Index()
        {
            return View();
        }


        public IActionResult GetFixtures()
        {
            FixtureManager fixture = new FixtureManager(_httpClientFactory);
            var result = fixture.GetFixtures();

            return Content(result.Result);
        }

        public IActionResult GetFixture([FromBody] Fixture parameter)
        {
            if (parameter.UserId == 0)
            {
                parameter.UserId = WorkingUser;
            }

            var result = fixture.GetFixture(parameter);
            return Content(result.Result);
        }

        public IActionResult GetFixtureByUser()
        {
            Fixture parameter = new Fixture();
            parameter.UserId = WorkingUser;

            var result = fixture.GetFixtureByUser(parameter);

            return Content(result.Result);
        }

        public IActionResult AddFixture([FromBody] Fixture parameter)
        {
            var result = fixture.AddFixture(parameter);

            return Content(result.Result);
        }

        public IActionResult UpdateFixture([FromBody] Fixture parameter)
        {
            var result = fixture.UpdateFixture(parameter);

            return Content(result.Result);
        }

        public IActionResult DeleteFixture([FromBody] Fixture parameter)
        {
            var result = fixture.DeleteFixture(parameter);

            return Content(result.Result);
        }
    }
}
