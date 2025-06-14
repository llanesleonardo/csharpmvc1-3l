using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Tresele.crmbe.Endpoints;
using Tresele.crmbe.Services;
using Tresele.crmbe.Services.Interfaces;
using Microsoft.OpenApi.Models;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(); // ✅ Enables Razor Views

// Set the HTTP port
if (builder.Environment.IsDevelopment())
{
    builder.WebHost.ConfigureKestrel(serverOptions =>
    {
        serverOptions.ListenAnyIP(5050);
    });
}
else
{
    var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
    builder.WebHost.UseUrls($"http://*:{port}");
}

// 🔽 Add this code right after creating the builder
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables();

builder.Services.AddEndpointsApiExplorer(); // <-- REQUIRED for Swagger to find endpoints
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Tresele CRM API",
        Version = "v1",
        Description = "API for managing weather forecasts and other CRM features."
    });
});

// 📦 Register Services
builder.Services.AddSingleton<IWeatherForecastService, WeatherForecastService>();
builder.Services.AddSingleton<IUserService, UserService>();

// 👀 Enable MVC (for Razor Pages / Views / Controllers)
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();

var app = builder.Build();
// Optional middleware
app.UseStaticFiles();

// 📦 Enable Swagger UI (in all environments)
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Tresele CRM API v1");
    options.RoutePrefix = "swagger"; // So it's at /swagger
});


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapUserEndpoints();
app.MapWeatherForecastEndpoints();

app.Run();