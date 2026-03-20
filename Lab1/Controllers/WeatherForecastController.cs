using Microsoft.AspNetCore.Mvc;
using Lab1.Services;
using Lab1.Models;
using Lab1.Models.Enums;

namespace Lab1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        private static readonly string[] Summaries =
        [
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        ];

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("temperature/{cityId}")]
        public string GetTempForCity(int cityId, [FromServices] ITemperatureService temperatureService)
        {
            return temperatureService.GetTempForCity(cityId);
        }
        [HttpGet("winddirection")]
        public string GetWindDirection([FromServices] IWindService windService)
        {
            return windService.GetWindDirection();
        }
        [HttpGet("forecast/{cityName}")]
        public Task<WeatherResponse> GetWeatherForecastAsync(string cityName, [FromServices] IWeatherForecastService weahterService)
        {
            return weahterService.GetWeatherForecastAsync(cityName);
        }
    }
}