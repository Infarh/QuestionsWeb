using Microsoft.AspNetCore.Mvc;

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
        _Logger.LogInformation("Вызов Index");

        return Content("Data from controller");
    }

    public IActionResult TestAction(int id)
    {
        _Logger.LogInformation("Вызов TestAction c параметром {id}", id);

        return Content($"Data from test action {id}");
    }

    public IActionResult ConfigData(string Parameter = "TestString")
    {
        var value = _Config[Parameter];

        return Content(value ?? "");
    }
}
