using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuestionsWeb.Domain.Entities.Identity;

namespace QuestionsWeb.Areas.Admin.Controllers;

//[Area("Admin")]
[Authorize(Roles = Role.Adinistrators)]
public class HomeController : Controller
{
    public IActionResult Index() => View();
}
