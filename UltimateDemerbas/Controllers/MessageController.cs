using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UltimateDemerbas.Entities;
using UltimateDemerbas.Manager;

namespace UltimateDemerbas.Controllers
{
    public class MessageController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public MessageController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult GetMessages()
        {
            Message parameter = new Message();
            parameter.UserId = Convert.ToInt32(Request.Cookies["id"]);

            MessageManager message = new MessageManager(_httpClientFactory);
            var result = message.GetMessages(parameter);

            return Content(result.Result);
        }

        public IActionResult DeleteMessage([FromBody] Message parameter)
        {
            parameter.UserId = Convert.ToInt32(Request.Cookies["id"]);
           
            MessageManager message = new MessageManager(_httpClientFactory);
            var result = message.DeleteMessage(parameter);

            return Content(result.Result);
        }

        public IActionResult AddMessage([FromBody] Message parameter)
        {
            parameter.UserId = Convert.ToInt32(Request.Cookies["id"]);

            MessageManager message = new MessageManager(_httpClientFactory);
            var result = message.AddMessage(parameter);

            return Content(result.Result);
        }
    }
}
