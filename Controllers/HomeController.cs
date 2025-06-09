using Microsoft.AspNetCore.Mvc;
using Tresele.crmbe.Models;
using System.Net.Http.Json;

namespace Tresele.crmbe.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<IActionResult> Index()
        {
            var forecasts = await _httpClient.GetFromJsonAsync<List<WeatherForecast>>("http://localhost:5050/weatherforecast");
            return View(forecasts); // passes the model to Index.cshtml
        }

        public async Task<IActionResult> About()
        {
            var forecasts = await _httpClient.GetFromJsonAsync<List<WeatherForecast>>("http://localhost:5050/weatherforecast");
            return View(forecasts); // will look for Views/Home/About.cshtml
        }

        public async Task<IActionResult> Services()
        {
            var forecasts = await _httpClient.GetFromJsonAsync<List<WeatherForecast>>("http://localhost:5050/weatherforecast");
            return View(forecasts); // will look for Views/Home/Services.cshtml
        }


        public async Task<IActionResult> Contact()
        {
            var forecasts = await _httpClient.GetFromJsonAsync<List<WeatherForecast>>("http://localhost:5050/weatherforecast");
            return View(forecasts); // will look for Views/Home/Contact.cshtml
        }

    }
}
