using Microsoft.AspNetCore.Mvc;
using QuestionsWeb.Interfaces.Services;

namespace QuestionsWeb.Components;
public class TemperatureViewComponent : ViewComponent
{
    private readonly IWeatherService _Weather;

    public TemperatureViewComponent(IWeatherService Weather)
    {
        _Weather = Weather;
    }

    public async Task<IViewComponentResult> InvokeAsync(string Location)
    {
        var weather = await _Weather.GetCurrentWeatherAsync(Location);

        return View(weather);
    }
}
