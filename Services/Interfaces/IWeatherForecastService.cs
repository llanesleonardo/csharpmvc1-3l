using Tresele.crmbe.Models;
namespace Tresele.crmbe.Services.Interfaces;

public interface IWeatherForecastService
{
    IEnumerable<WeatherForecast> GetAll();
    void Add(WeatherForecast forecast);
    bool Update(int id, WeatherForecast updated);
    bool Delete(int id);
}
