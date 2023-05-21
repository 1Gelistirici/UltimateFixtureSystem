﻿using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using UltimateAPI.Entities;
using UltimateDemerbas.Manager;
using UltimateDemerbas.Models.Tool;

namespace UltimateDemerbas.Controllers
{
    [CheckAuthorize]
    public class BillController : BaseController
    {
        protected override int PageNumber { get; set; } = 32;
        private readonly IHttpClientFactory _httpClientFactory;
        BillManager bill;
        public BillController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            bill = new BillManager(_httpClientFactory);
        }


        [CheckAuthorize]
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult GetBills()
        {
            var result = bill.GetBills();
            return Content(result.Result);
        }

        public IActionResult DeleteBill([FromBody] Bill parameter)
        {
            parameter.UserId = WorkingUser;
            var result = bill.DeleteBill(parameter);
            return Content(result.Result);
        }

        public IActionResult AddBill([FromBody] Bill parameter)
        {
            parameter.UserId = WorkingUser;
            var result = bill.AddBill(parameter);
            return Content(result.Result);
        }

        public IActionResult GetBillByCompanyRefId()
        {
            var result = bill.GetBillByCompanyRefId(new ReferansParameter() { RefId = WorkingCompany });
            return Content(result.Result);
        }

        public IActionResult UpdateBill([FromBody] Bill parameter)
        {
            parameter.UserId = WorkingUser;
            var result = bill.UpdateBill(parameter);
            return Content(result.Result);
        }

        public IActionResult DeleteBillItem([FromBody] BillItem parameter)
        {
            var result = bill.DeleteBillItem(parameter);
            return Content(result.Result);
        }

        public IActionResult AddBillItem([FromBody] BillItem parameter)
        {
            parameter.Id = WorkingUser;
            var result = bill.AddBillItem(parameter);
            return Content(result.Result);
        }

    }
}
