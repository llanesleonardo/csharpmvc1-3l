using Microsoft.AspNetCore.Mvc;
using Tresele.crmbe.Models;
using System.Net.Http.Json;

namespace Tresele.crmbe.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl;
        public HomeController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _apiBaseUrl = configuration["ApiBaseUrl"];
        }

        public async Task<IActionResult> Index()
        {
            var forecasts = await _httpClient.GetFromJsonAsync<List<WeatherForecast>>($"{_apiBaseUrl}/weatherforecast");
            return View(forecasts); // passes the model to Index.cshtml
        }

        public async Task<IActionResult> About()
        {
            var forecasts = await _httpClient.GetFromJsonAsync<List<WeatherForecast>>($"{_apiBaseUrl}/weatherforecast");
            return View(forecasts); // will look for Views/Home/About.cshtml
        }

        public async Task<IActionResult> Services()
        {
            var forecasts = await _httpClient.GetFromJsonAsync<List<WeatherForecast>>($"{_apiBaseUrl}/weatherforecast");
            return View(forecasts); // will look for Views/Home/Services.cshtml
        }


        public async Task<IActionResult> Contact()
        {
            var forecasts = await _httpClient.GetFromJsonAsync<List<WeatherForecast>>($"{_apiBaseUrl}/weatherforecast");
            return View(forecasts); // will look for Views/Home/Contact.cshtml
        }

    }
}
