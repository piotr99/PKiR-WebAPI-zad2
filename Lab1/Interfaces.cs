using Lab1.Models;

namespace Lab1;

public interface ITemperatureService
{
    string GetTempForCity(int cityId);
}
public interface IWindService
{
    string GetWindDirection();
}
public interface IWeatherForecastService
{
    Task<WeatherResponse> GetWeatherForecastAsync(string cityName);
}
public interface IScriptService
{
    Task<bool> PostScript(string script);
}