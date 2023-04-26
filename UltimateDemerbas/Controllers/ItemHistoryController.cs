using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using UltimateAPI.Entities;
using UltimateDemerbas.Manager;
using UltimateDemerbas.Models.Tool;

namespace UltimateDemerbas.Controllers
{
    [CheckAuthorize]
    public class ItemHistoryController : BaseController
    {
        protected override int PageNumber { get; set; } = 28;
        private readonly IHttpClientFactory _httpClientFactory;
        ItemHistoryManager itemHistory;
        public ItemHistoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            itemHistory = new ItemHistoryManager(_httpClientFactory);
        }


        public IActionResult GetItemHistoryByCompany()
        {
            var result = itemHistory.GetItemHistoryByCompany(new ReferansParameter() { RefId = WorkingCompany });
            return Content(result.Result);
        }

        public IActionResult AddAccessory([FromBody] ItemHistory parameter)
        {
            parameter.TransactionUserRefId = WorkingUser;
            var result = itemHistory.AddItemHistory(parameter);
            return Content(result.Result);
        }

    }
}
