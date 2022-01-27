﻿using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace UltimateDemerbas.Manager
{
    public class BaseManager : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public BaseManager(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }





        public string apiAdress = "https://localhost:44354/api/";

        public StringContent GetSerilizatiob<T>(T ConvertData)
        {
            var ConvertJson = new StringContent(
                  JsonSerializer.Serialize(ConvertData),
                  Encoding.UTF8,
                  "application/json");

            return ConvertJson;
        }


        public void Error(Exception ex)
        {
            WriteError(ex);
        }

        private void WriteError(Exception ex)
        {
            try
            {
                string root = @"C:\UFS";
                string subdir = @"C:\UFS\UI";

                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }


                if (!Directory.Exists(subdir))
                {
                    Directory.CreateDirectory(subdir);
                }

                string fileName = "ErrorUltimateUI.txt";
                string targetFile = System.IO.Path.Combine(subdir, fileName);

                if (!System.IO.File.Exists(targetFile))
                {
                    var file = System.IO.File.Create(targetFile);
                    file.Close();
                }
                System.IO.File.WriteAllText(targetFile, ex.ToString());
            }
            catch (Exception)
            {

            }
        }


        public async Task<string> GetApi(string goUrl)
        {
            var url = apiAdress + goUrl;
            var httpClient = _httpClientFactory.CreateClient("Test");

            try
            {
                var response = await httpClient.GetAsync(url);
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                Error(ex);
                return null;
            }
        }

        public async Task<string> GetApiParameter<T>(string goUrl, T parameter)
        {
            var url = apiAdress + goUrl;
            var httpClient = _httpClientFactory.CreateClient("Test");
            var JsonData = GetSerilizatiob<T>(parameter);

            try
            {
                var response = await httpClient.PostAsync(url, JsonData);
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                Error(ex);
                return null;
            }
        }




        //public int ActiveUserId { get { return Convert.ToInt32(Request.Cookies["id"]); } }
        //public string ActiveUserCompany { get { return Request.Cookies["company"]; } }

    }
}
