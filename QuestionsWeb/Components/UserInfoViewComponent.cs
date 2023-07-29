using Microsoft.AspNetCore.Mvc;

namespace QuestionsWeb.Components;

public class UserInfoViewComponent : ViewComponent
{
    public IViewComponentResult Invoke() => User.Identity?.IsAuthenticated ?? false
        ? View("Info")
        : View();
}
