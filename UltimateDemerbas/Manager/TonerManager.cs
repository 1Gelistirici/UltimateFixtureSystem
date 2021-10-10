using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using UltimateDemerbas.Entities;
using UltimateDemerbas.Models;

namespace UltimateDemerbas.Manager
{
    public class TonerManager : BaseManager
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TonerManager(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> GetToners()
        {
            var url = apiAdress + $"/Toner/GetToners";
            var httpClient = _httpClientFactory.CreateClient("Test"); ;

            try
            {
                var response = await httpClient.GetAsync(url);
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<string> DeleteToner(Toner parameter)
        {
            var url = apiAdress + $"/Toner/DeleteToner";
            var httpClient = _httpClientFactory.CreateClient("Test"); ;
            var JsonData = GetSerilizatiob<Toner>(parameter);

            try
            {
                var response = await httpClient.PostAsync(url, JsonData);
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<string> UpdateToner(Toner parameter)
        {
            var url = apiAdress + $"/Toner/UpdateToner";
            var httpClient = _httpClientFactory.CreateClient("Test"); ;
            var JsonData = GetSerilizatiob<Toner>(parameter);

            try
            {
                var response = await httpClient.PostAsync(url, JsonData);
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<string> AddToner(Toner parameter)
        {
            var url = apiAdress + $"/Toner/AddToner";
            var httpClient = _httpClientFactory.CreateClient("Test"); ;
            var JsonData = GetSerilizatiob<Toner>(parameter);

            try
            {
                var response = await httpClient.PostAsync(url, JsonData);
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }









        //public async Task<string> GetToner(Login login)
        //{
        //    var url = $"https://localhost:44354/api/Toner/GetToner";
        //    var httpClient = _httpClientFactory.CreateClient("Test"); ;
        //    var JsonData = GetSerilizatiob<Login>(login);

        //    try
        //    {
        //        var response = await httpClient.PostAsync(url, JsonData);
        //        return await response.Content.ReadAsStringAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

        //public async Task<string> GetToners()
        //{
        //    var url = $"https://localhost:44354/api/Toner/GetToners";
        //    var httpClient = _httpClientFactory.CreateClient("Test"); ;

        //    try
        //    {
        //        var response = await httpClient.GetAsync(url);
        //        return await response.Content.ReadAsStringAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

    }
}
