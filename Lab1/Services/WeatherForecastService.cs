using Lab1.Models;

namespace Lab1.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public WeatherForecastService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["OpenWeather:ApiKey"];
        }

        public async Task<WeatherResponse?> GetWeatherForecastAsync(string cityName)
        {
            if (string.IsNullOrWhiteSpace(cityName))
                return null;

            var url = $"data/2.5/weather?q={cityName}&units=metric&appid={_apiKey}";

            try
            {
                var response = await _httpClient.GetFromJsonAsync<WeatherResponse>(url);
                return response;
            }
            catch (HttpRequestException)
            {
                return null;
            }
        }
    }
}