using QuestionsWeb.Domain.Models.Weather;

namespace QuestionsWeb.Interfaces.Services;

public interface IWeatherService
{
    Task<WeatherInfo> GetCurrentWeatherAsync(string Location, CancellationToken Cancel = default);
}
