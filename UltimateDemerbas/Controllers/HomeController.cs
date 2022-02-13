using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using UltimateDemerbas.Models;
using UltimateDemerbas.Models.Tool;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace UltimateDemerbas.Controllers
{
    public class HomeController : BaseController
    {
        protected override int PageNumber { get; set; } = 0;


        [CheckAuthorize]
        public IActionResult Index()
        {
            return View();
        }

        [CheckAuthorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }






        public async Task<string> Login()
        {

            var httpClient = _httpClientFactory.CreateClient("Test"); ;
            var url = $"http://localhost:4000/users/authenticate";
            var response = await httpClient.GetAsync(url);
            return await response.Content.ReadAsStringAsync();


        }


        public async Task<string> Login1([FromBody] Login login)
        {

            var httpClient = _httpClientFactory.CreateClient("Test"); ;

            var todoItemJson = new StringContent(
                    JsonSerializer.Serialize(login),
                    Encoding.UTF8,
                    "application/json");
            try
            {
                var url = $"https://localhost:44354/api/Toner/GetToner";
                var response = await httpClient.PostAsync(url, todoItemJson);
                return await response.Content.ReadAsStringAsync();

            }
            catch (Exception ex)
            {
                return null;
            }
            

        }


        private static readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions
        {
            IgnoreNullValues = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

       
        public async Task CreateItemAsync(Login login)
        {
            try
            {
                HttpClient _httpClient = new HttpClient();
                var todoItemJson = new StringContent(
                    JsonSerializer.Serialize(login),
                    Encoding.UTF8,
                    "application/json");
                var url = $"http://localhost:44359/api/TodoItems";
                 var httpResponse =
                    await _httpClient.PostAsync(url, todoItemJson);

                httpResponse.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {

            
            }
            
        }




        public async Task<IActionResult> Tst1(Login login)
        {


            return (IActionResult)CreateItemAsync(login);
        }


        public async Task<IActionResult> Tst(Login login)
        {
           HttpClient _httpClient = new HttpClient();
            login.Username = "test";
            login.Password = "test";
       
            
            var todoItemJson = new StringContent(
             JsonSerializer.Serialize(login, _jsonSerializerOptions),
             Encoding.UTF8,
             "application/json");

            using var httpResponse =
                await _httpClient.PostAsync($"http://localhost:44359/api/TodoItems", todoItemJson);
            httpResponse.EnsureSuccessStatusCode();

            return View();
        }


    





    }
}
