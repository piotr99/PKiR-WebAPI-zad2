using Lab1;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSingleton<ITemperatureService, TemperatureService>();
builder.Services.AddSingleton<IWindService, WindService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.MapGet("/", () => "Hello World!");
app.MapGet("/temperature/{cityId:int}", (int cityId, ITemperatureService tempService) =>
{
    return tempService.GetTempForCity(cityId);
});
app.MapGet("/winddirection", (IWindService windService) =>
{
    return windService.GetWindDirection();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
