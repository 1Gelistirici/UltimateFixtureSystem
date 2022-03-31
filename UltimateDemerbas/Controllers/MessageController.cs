using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using UltimateAPI.Entities;
using UltimateDemerbas.Manager;
using UltimateDemerbas.Models.Tool;

namespace UltimateDemerbas.Controllers
{
    [CheckAuthorize]
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

        [CheckAuthorize]
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult GetMessages()
        {
            Message parameter = new Message();
            parameter.UserId = WorkingUser;

            var result = message.GetMessages(parameter);

            return Content(result.Result);
        }

        public IActionResult DeleteMessage([FromBody] Message parameter)
        {
            parameter.UserId = WorkingUser;

            var result = message.DeleteMessage(parameter);

            return Content(result.Result);
        }

        public IActionResult AddMessage([FromBody] Message parameter)
        {
            parameter.UserId = WorkingUser;

            var result = message.AddMessage(parameter);

            return Content(result.Result);
        }
    }
}
