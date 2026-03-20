using Lab1;
using Lab1.Services;
using Microsoft.AspNetCore.Mvc;
using Lab1.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ITemperatureService, TemperatureService>();
builder.Services.AddSingleton<IWindService, WindService>();
builder.Services.AddSingleton<IScriptService, ScriptService>();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
