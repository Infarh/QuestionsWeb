using Microsoft.AspNetCore.Mvc;

namespace QuestionsWeb.Controllers;

public class BlogController : Controller
{
    private readonly ILogger<BlogController> _Logger;

    public BlogController(ILogger<BlogController> Logger)
    {
        _Logger = Logger;
    }

    public IActionResult Index() => View();
}
