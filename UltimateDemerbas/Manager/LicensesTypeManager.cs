﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UltimateDemerbas.Entities;
using UltimateDemerbas.Models;

namespace UltimateDemerbas.Manager
{
    public class LicensesTypeManager : BaseManager
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LicensesTypeManager(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<string> GetLicensesTypes()
        {
            var url = apiAdress + $"/LicanseType/GetLicensesTypes";
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

        public async Task<string> GetLicensesType(LicensesType parameter)
        {
            var url = apiAdress + $"/LicanseType/GetLicensesType";
            var httpClient = _httpClientFactory.CreateClient("Test"); ;
            var JsonData = GetSerilizatiob<LicensesType>(parameter);

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
        
        public async Task<string> DeleteLicensesType(LicensesType parameter)
        {
            var url = apiAdress + $"/LicanseType/DeleteLicensesType";
            var httpClient = _httpClientFactory.CreateClient("Test"); ;
            var JsonData = GetSerilizatiob<LicensesType>(parameter);

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

        public async Task<string> AddLicenseType(LicensesType parameter)
        {
            var url = apiAdress + $"/LicanseType/AddLicenseType";
            var httpClient = _httpClientFactory.CreateClient("Test"); ;
            var JsonData = GetSerilizatiob<LicensesType>(parameter);

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
        
        public async Task<string> UpdateLicenseType(LicensesType parameter)
        {
            var url = apiAdress + $"/LicanseType/UpdateLicenseType";
            var httpClient = _httpClientFactory.CreateClient("Test"); ;
            var JsonData = GetSerilizatiob<LicensesType>(parameter);

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

    }
}
