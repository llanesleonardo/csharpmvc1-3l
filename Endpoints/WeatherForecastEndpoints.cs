using Tresele.crmbe.Models;
using Tresele.crmbe.Services.Interfaces;
namespace Tresele.crmbe.Endpoints;

public static class WeatherForecastEndpoints
{
    public static void MapWeatherForecastEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/weatherforecast", (IWeatherForecastService service) =>
        {
            return Results.Ok(service.GetAll());
        });

        app.MapPost("/weatherforecast", (WeatherForecast forecast, IWeatherForecastService service) =>
        {
            service.Add(forecast);
            return Results.Created("/weatherforecast", forecast);
        });

        app.MapPut("/weatherforecast/{id}", (int id, WeatherForecast forecast, IWeatherForecastService service) =>
        {
            return service.Update(id, forecast) ? Results.NoContent() : Results.NotFound();
        });

        app.MapDelete("/weatherforecast/{id}", (int id, IWeatherForecastService service) =>
        {
            return service.Delete(id) ? Results.Ok() : Results.NotFound();
        });
    }
}