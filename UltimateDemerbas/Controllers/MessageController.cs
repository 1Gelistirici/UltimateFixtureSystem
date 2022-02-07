using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using UltimateAPI.Entities;
using UltimateDemerbas.Manager;

namespace UltimateDemerbas.Controllers
{
    public class MessageController : BaseController
    {
        protected override int PageNumber { get; set; } = 0;
        private readonly IHttpClientFactory _httpClientFactory;
        MessageManager message;
        public MessageController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            message = new MessageManager(_httpClientFactory);
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult GetMessages()
        {
            Message parameter = new Message();
            parameter.UserId = Convert.ToInt32(Request.Cookies["id"]);

            var result = message.GetMessages(parameter);

            return Content(result.Result);
        }

        public IActionResult DeleteMessage([FromBody] Message parameter)
        {
            parameter.UserId = Convert.ToInt32(Request.Cookies["id"]);

            var result = message.DeleteMessage(parameter);

            return Content(result.Result);
        }

        public IActionResult AddMessage([FromBody] Message parameter)
        {
            parameter.UserId = Convert.ToInt32(Request.Cookies["id"]);

            var result = message.AddMessage(parameter);

            return Content(result.Result);
        }
    }
}
