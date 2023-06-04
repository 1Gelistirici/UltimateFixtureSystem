using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using UltimateAPI.Entities;
using UltimateDemerbas.Manager;
using UltimateDemerbas.Models.Tool;

namespace UltimateDemerbas.Controllers
{
    public class FeedbackController : BaseController
    {
        protected override int PageNumber { get; set; } = 39;
        private readonly IHttpClientFactory _httpClientFactory;
        FeedbackManager feedback;

        public FeedbackController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            feedback = new FeedbackManager(_httpClientFactory);
        }


        [CheckAuthorize]
        public IActionResult Index()
        {
            return View();
        }

        [CheckAuthorize]
        public IActionResult GetFeedbackByUser()
        {
            var result = feedback.GetFeedbackByUser(new ReferansParameter() { RefId = WorkingUser });
            return Content(result.Result);
        }

        [CheckAuthorize]
        public IActionResult AddFeedback([FromBody] Feedback parameter)
        {
            parameter.UserRefId = WorkingUser;
            var result = feedback.AddFeedback(parameter);
            return Content(result.Result);
        }

    }
}
