using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using QuestionsWeb.Domain.Models.Weather;
using QuestionsWeb.Interfaces.Services;

namespace QuestionsWeb.Services;

public class WeatherApiComService : IWeatherService
{
    private readonly HttpClient _Client;
    private readonly ILogger<WeatherApiComService> _Logger;

    public WeatherApiComService(HttpClient Client, ILogger<WeatherApiComService> Logger)
    {
        _Client = Client;
        _Logger = Logger;
    }

    public async Task<WeatherInfo> GetCurrentWeatherAsync(string Location, CancellationToken Cancel = default)
    {
        var weather = await _Client.GetFromJsonAsync<WeatherInfo>(
            $"/v1/current.json?q={Location}", 
            cancellationToken: Cancel);

        return weather!;
    }
}
