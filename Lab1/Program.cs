using Lab1;
using Lab1.Services;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ITemperatureService, Lab1.Services.TemperatureService>();
builder.Services.AddSingleton<IWindService, Lab1.Services.WindService>();
builder.Services.AddSingleton<IScriptService, Lab1.Services.ScriptService>();
builder.Services.AddHttpClient<IWeatherForecastService, WeatherForecastService>((sp, client) =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();
    var apiKey = configuration["OpenWeather:ApiKey"];

    client.BaseAddress = new Uri("https://api.openweathermap.org/");
    client.Timeout = TimeSpan.FromSeconds(5); //nnot in use
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapGet("/", () => "Hello World!");
app.MapGet("/temperature/{cityId}", (int cityId, ITemperatureService tempService) =>
{
    return tempService.GetTempForCity(cityId);
});
app.MapGet("/winddirection", (IWindService windService) =>
{
    return windService.GetWindDirection();
});
app.MapGet("/forecast/{cityName}", (string cityName, IWeatherForecastService weahterService) =>
{
    return weahterService.GetWeatherForecastAsync(cityName);
});
app.MapPost("/weatherPresenterScript", async (string script, [FromServices] IScriptService scriptService) =>
{
    var isSuccess = await scriptService.PostScript(script);
    return isSuccess ? Results.Ok("działa") : Results.BadRequest("bład czegos");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
