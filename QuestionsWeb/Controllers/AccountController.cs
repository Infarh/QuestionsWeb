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
        //if (model.Password != model.PasswordConfirm)
        //{
        //    ModelState.AddModelError(nameof(RegisterUserViewModel.Password), "Пароли не совпадают");
        //    return View(model);
        //}

        if (!ModelState.IsValid)
            return View(model);

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

    public IActionResult Login(string? ReturnUrl) => View(new LoginViewModel { ReturnUrl = ReturnUrl });

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var sign_in_result = await _SignInManager.PasswordSignInAsync(
            model.Login,
            model.Password,
            model.RememberMe,
            true);

        if (sign_in_result.Succeeded)
        {
            _Logger.LogInformation("Пользователь {user} успешно вошёл в систему", model.Login);

            //return RedirectToAction("Index", "Home");

            //return Redirect(model.ReturnUrl ?? "/"); // Не безопасно!

            //if (Url.IsLocalUrl(model.ReturnUrl))
            //    return Redirect(model.ReturnUrl ?? "/");
            //return RedirectToAction("Index", "Home");

            return LocalRedirect(model.ReturnUrl ?? "/");
        }

        //if (sign_in_result.RequiresTwoFactor)
        //{
        //    _Logger.LogInformation("Пользователю {user} требуется двухфакторная авторизация", model.Login);
        //    // Требуется двухфакторная авторизация
        //}

        if (sign_in_result.IsLockedOut)
        {
            _Logger.LogInformation("Пользователь {user} заблокирован", model.Login);
        }

        ModelState.AddModelError("", "Неверное имя пользователя, или пароль");
        return View(model);
    }

    public async Task<IActionResult> Logout()
    {
        var user = User.Identity!.Name;

        await _SignInManager.SignOutAsync();

        var user2 = User.Identity?.Name;

        _Logger.LogInformation("Пользователь {user} вышел из системы", user);

        return RedirectToAction("Index", "Home");
    }

    public IActionResult AccessDenied() => View();

    public IActionResult Profile() => NotFound();
}
