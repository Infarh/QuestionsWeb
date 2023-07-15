using Microsoft.AspNetCore.Mvc;

namespace QuestionsWeb.Components;

public class BlogPostCardViewComponent : ViewComponent
{
    public IViewComponentResult Invoke() => View();
}