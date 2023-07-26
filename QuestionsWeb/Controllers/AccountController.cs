using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuestionsWeb.Domain.Entities.Identity;
using QuestionsWeb.ViewModels;

namespace QuestionsWeb.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<User> _UserManager;
    private readonly SignInManager<User> _SignInManager;
    private readonly ILogger<AccountController> _Logger;

    public AccountController(
        UserManager<User> UserManager,
        SignInManager<User> SignInManager,
        ILogger<AccountController> Logger)
    {
        _UserManager = UserManager;
        _SignInManager = SignInManager;
        _Logger = Logger;
    }

    public IActionResult SignUp() => View(new RegisterUserViewModel());

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> SignUp(RegisterUserViewModel model)
    {
        var user = new User
        {
            UserName = model.UserName,
        };

        var confirm_email_token = await _UserManager.GenerateEmailConfirmationTokenAsync(user);
        var url = Url.Action("ConfirmEmail", new { token = confirm_email_token }); 

        var creation_result = await _UserManager.CreateAsync(user, model.Password);
        if (creation_result.Succeeded)
        {
            _Logger.LogInformation("Пользователь {user} успешно зарегистрирован", user.UserName);

            await _UserManager.AddToRoleAsync(user, Role.Users);

            await _SignInManager.SignInAsync(user, isPersistent: false);

            return RedirectToAction("Index", "Home");
        }

        foreach (var error in creation_result.Errors)
        {
            _Logger.LogWarning("Ошибка при регистрации пользователя {user}:{error}", user.UserName, error);
            ModelState.AddModelError("", error.Description);
        }

        return View(model);
    }

    public async Task<IActionResult> ConfirmEmail(string token)
    {
        //await _UserManager.ConfirmEmailAsync(User.Identity as User, token);
        return RedirectToAction("Index", "Home");
    }

    public IActionResult Login() => View();
}
