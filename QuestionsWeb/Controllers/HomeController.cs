using Microsoft.AspNetCore.Mvc;

namespace QuestionsWeb.Controllers;

public class HomeController : Controller
{
    public HomeController()
    {
        
    }

    public IActionResult Index()
    {
        return Content("Data from controller");
    }

    public IActionResult TestAction(int id)
    {
        return Content($"Data from test action {id}");
    }
}
