using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using UltimateAPI.Entities;
using UltimateDemerbas.Manager;

namespace UltimateDemerbas.Controllers
{
    public class BillTypeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        BillTypeManager billType;
        public BillTypeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            billType = new BillTypeManager(_httpClientFactory);
        }


        public IActionResult Index()
        {
            return View();
        }


        public IActionResult GetBillTypes()
        {
            BillTypeManager billType = new BillTypeManager(_httpClientFactory);
            var result = billType.GetBillTypes();

            return Content(result.Result);
        }

        public IActionResult DeleteBillType([FromBody] BillType parameter)
        {
            parameter.UserId = Convert.ToInt32(Request.Cookies["id"]);
            var result = billType.DeleteBillType(parameter);
            return Content(result.Result);
        }

        public IActionResult AddBillType([FromBody] BillType parameter)
        {
            parameter.UserId = Convert.ToInt32(Request.Cookies["id"]);
            var result = billType.AddBillType(parameter);
            return Content(result.Result);
        }

        public IActionResult UpdateBillType([FromBody] BillType parameter)
        {
            parameter.UserId = Convert.ToInt32(Request.Cookies["id"]);
            var result = billType.UpdateBillType(parameter);
            return Content(result.Result);
        }
    }
}
