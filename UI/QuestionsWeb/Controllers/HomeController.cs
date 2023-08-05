using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using QuestionsWeb.Interfaces.Services;

namespace QuestionsWeb.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _Logger;
    private readonly IConfiguration _Config;

    public HomeController(ILogger<HomeController> Logger, IConfiguration config)
    {
        _Logger = Logger;
        _Config = config;
    }

    public IActionResult Index()
    {
        var timer = Stopwatch.StartNew();
        _Logger.LogInformation("Вызов Index");
        try
        {
            // передача и получение данных из сервисов
            return View();
        }
        catch (InvalidOperationException error)
        {
            _Logger.LogWarning("Ошибка при обработке запроса {error}", error);
            return BadRequest($"Ошибка при обработке запроса {error.Message}");
        }
        finally
        {
            _Logger.LogInformation("Обработка запроса завершена за {timeout}", timer.Elapsed);
        }
    }

    public IActionResult TestAction(int id)
    {
        _Logger.LogInformation("Вызов TestAction c параметром {id}", id);

        return View();
    }

    public IActionResult ConfigData(string Parameter = "TestString")
    {
        var value = _Config[Parameter];

        return Content(value ?? "");
    }
}
