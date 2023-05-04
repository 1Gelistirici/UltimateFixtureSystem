using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using UltimateAPI.Entities;
using UltimateAPI.Entities.Enums;
using UltimateDemerbas.Manager;
using UltimateDemerbas.Models.Tool;

namespace UltimateDemerbas.Controllers
{
    [CheckAuthorize]
    public class CompanyController : BaseController
    {
        protected override int PageNumber { get; set; } = 60;
        private readonly IHttpClientFactory _httpClientFactory;
        private IConfiguration Configuration;
        CompanyManager company;
        public CompanyController(IHttpClientFactory httpClientFactory, IConfiguration _configuration)
        {
            _httpClientFactory = httpClientFactory;
            company = new CompanyManager(_httpClientFactory);
            Configuration = _configuration;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult GetCompanies()
        {
            var result = company.GetCompanies();
            return Content(result.Result);
        }

        public IActionResult GetCompanyGroup()
        {
            FileHelper fileHelper = new FileHelper(Configuration);
            string folder = fileHelper.GetSaveURL(SaveFile.Company, WorkingCompany);

            var response = company.GetCompanyGroup(new ReferansParameter() { RefId = WorkingCompany });

            UltimateResult<List<Company>> result = JsonSerializer.Deserialize<UltimateResult<List<Company>>>(response.Result);
            foreach (var item in result.Data)
            {
                if (item.LogoUrl != "")
                {
                    item.LogoUrl = Path.Combine(folder, item.LogoUrl);

                    byte[] imageData = System.IO.File.ReadAllBytes(item.LogoUrl);
                    string base64ImageRepresentation = Convert.ToBase64String(imageData);

                    item.LogoUrl = base64ImageRepresentation;

                }
                else
                {
                    item.LogoUrl = "";
                }
            }

            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }

        public IActionResult GetCompany([FromBody] ReferansParameter parameter)
        {
            var result = company.GetCompany(parameter);
            return Content(result.Result);
        }

        public IActionResult DeleteCompany([FromBody] ReferansParameter parameter)
        {
            var result = company.DeleteCompany(parameter);
            return Content(result.Result);
        }

        public IActionResult AddCompany([FromBody] Company parameter)
        {
            var result = company.AddCompany(parameter);
            return Content(result.Result);
        }

        public IActionResult UpdateComponent([FromBody] Company parameter)
        {
            var result = company.UpdateCompany(parameter);
            return Content(result.Result);
        }

    }
}
