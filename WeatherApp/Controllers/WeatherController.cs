
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WeatherApp.Models;

public class WeatherController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public WeatherController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
       
        string apiKey = "1234567890abcdef1234567890abcdef";
        string city = "NewJersy";

        // Create an HttpClient instance using the HttpClientFactory.
        var httpClient = _httpClientFactory.CreateClient();

        // Make an API request to OpenWeatherMap to retrieve weather data.
        HttpResponseMessage response = await httpClient.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric");

        if (response.IsSuccessStatusCode)
        {
            string json = await response.Content.ReadAsStringAsync();
            var weatherData = JsonConvert.DeserializeObject<WeatherData>(json);
            return View(weatherData);
        }
        else
        {
            // Handle API request error.
            ViewBag.ErrorMessage = "Failed to fetch weather data.";
            return View();
        }
    }
}
