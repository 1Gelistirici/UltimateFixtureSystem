using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using UltimateAPI.Entities;
using UltimateDemerbas.Manager;

namespace UltimateDemerbas.Controllers
{
    public class BillController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BillController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult GetBills()
        {
            BillManager bill = new BillManager(_httpClientFactory);
            var result = bill.GetBills();

            return Content(result.Result);
        }

        public IActionResult DeleteBill([FromBody] Bill parameter)
        {
            parameter.UserId = Convert.ToInt32(Request.Cookies["id"]);
            
            BillManager bill = new BillManager(_httpClientFactory);
            var result = bill.DeleteBill(parameter);

            return Content(result.Result);
        }

        public IActionResult AddBill([FromBody] Bill parameter)
        {
            parameter.UserId = Convert.ToInt32(Request.Cookies["id"]);

            BillManager bill = new BillManager(_httpClientFactory);
            var result = bill.AddBill(parameter);

            return Content(result.Result);
        }

        public IActionResult UpdateBill([FromBody] Bill parameter)
        {
            parameter.UserId = Convert.ToInt32(Request.Cookies["id"]);
         
            BillManager bill = new BillManager(_httpClientFactory);
            var result = bill.UpdateBill(parameter);

            return Content(result.Result);
        }
    }
}
