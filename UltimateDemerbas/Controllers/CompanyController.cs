using Functions;
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

        public IActionResult GetCompany()
        {
            FileHelper fileHelper = new FileHelper(Configuration);
            string folder = fileHelper.GetSaveURL(SaveFile.Company, WorkingCompany);

            var response = company.GetCompany(new ReferansParameter() { RefId = WorkingCompany });

            UltimateResult<Company> result = JsonSerializer.Deserialize<UltimateResult<Company>>(response.Result);
            if (result.IsSuccess)
            {
                if (result.Data.LogoUrl != "")
                {
                    result.Data.LogoUrl = Path.Combine(folder, result.Data.LogoUrl);

                    byte[] imageData = System.IO.File.ReadAllBytes(result.Data.LogoUrl);
                    string base64ImageRepresentation = Convert.ToBase64String(imageData);

                    result.Data.LogoUrl = base64ImageRepresentation;

                }
                else
                {
                    result.Data.LogoUrl = "";
                }
            }

            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
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

        public IActionResult UpdateCompany()
        {
            string folderUrl = "";

            try
            {
                FileHelper fileHelper = new FileHelper(Configuration);

                Company parameter = JsonHelper.JsonConvert<Company>(Request.Form["parameter"]);

                if (Request.Form.Files.Count > 0)
                {
                    var file = Request.Form.Files[0];
                    string folder = fileHelper.GetSaveURL(SaveFile.Company, WorkingCompany);

                    string fileGuId = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    folderUrl = Path.Combine(folder, fileGuId);

                    if (file != null)
                    {
                        if (System.IO.File.Exists(parameter.LogoUrl))
                        {
                            System.IO.File.Delete(parameter.LogoUrl);
                        }

                        UltimateResult<Company> result = new UltimateResult<Company>();
                        parameter.LogoUrl = folderUrl;

                        var response = company.UpdateCompany(parameter).Result;
                        result = JsonSerializer.Deserialize<UltimateResult<Company>>(response);

                        if (result.IsSuccess)
                        {
                            using (FileStream fs = System.IO.File.Create(folderUrl))
                            {
                                file.CopyTo(fs);
                            }
                        }

                        return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
                    }
                }
                else
                {
                    var result = company.UpdateCompany(parameter);
                    return Content(result.Result);
                }
            }
            catch (Exception ex)
            {
                if (folderUrl != "")
                {
                    System.IO.File.Delete(folderUrl);
                }
            }

            return Content("");
        }

    }
}
