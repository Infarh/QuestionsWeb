using Microsoft.AspNetCore.Mvc;

namespace QuestionsWeb.Controllers;

public class AccountController : Controller
{
    private readonly ILogger<AccountController> _Logger;

    public AccountController(ILogger<AccountController> Logger)
    {
        _Logger = Logger;
    }

    public IActionResult SignUp()
    {
        return View();
    }

    public IActionResult Login() => View();
}
