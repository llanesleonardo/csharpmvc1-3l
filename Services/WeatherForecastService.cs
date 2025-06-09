
using Tresele.crmbe.Models;
using Tresele.crmbe.Services.Interfaces;
namespace Tresele.crmbe.Services;

public class WeatherForecastService : IWeatherForecastService
{
    private readonly List<WeatherForecast> _forecasts = new()
    { 
        new(DateOnly.FromDateTime(DateTime.Now), 25, "Sunny"),
        new(DateOnly.FromDateTime(DateTime.Now.AddDays(1)), 28, "Hot")

    };

    public IEnumerable<WeatherForecast> GetAll() => _forecasts;

    public void Add(WeatherForecast forecast) => _forecasts.Add(forecast);

    public bool Update(int id, WeatherForecast updated)
    {
        if (id < 0 || id >= _forecasts.Count) return false;
        _forecasts[id] = updated;
        return true;
    }

    public bool Delete(int id)
    {
        if (id < 0 || id >= _forecasts.Count) return false;
        _forecasts.RemoveAt(id);
        return true;
    }
}