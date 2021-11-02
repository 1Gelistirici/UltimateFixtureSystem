using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace UltimateDemerbas.Manager
{
    public class BaseManager : Controller
    {
        //public readonly IHttpClientFactory _httpClientFactory;

        //public BaseManager(IHttpClientFactory httpClientFactory)
        //{
        //    _httpClientFactory = httpClientFactory;
        //}
        public string apiAdress = "https://localhost:44354/api";

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

        public int ActiveUserId { get { return Convert.ToInt32(Request.Cookies["id"]); } }
        public string ActiveUserCompany { get { return Request.Cookies["company"]; } }

    }
}
