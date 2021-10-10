using System;
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
                string fileName = "UltimateDemirbasUI.txt";
                string filePath = @"c:\";
                string targetFile = System.IO.Path.Combine(filePath, fileName);

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

        public int ActiveUserId { get { return GetId(); } }
        public string ActiveUserCompany { get { return GetCompany(); } }

        
        public int GetId()
        {
            var id = Request.Cookies["id"];
            return Convert.ToInt32(id);
        }

        public string GetCompany()
        {
            var company = Request.Cookies["company"];
            return company;
        }

  

    }
}
