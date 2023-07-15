using Microsoft.AspNetCore.Mvc;

using QuestionsWeb.ViewModels;

namespace QuestionsWeb.Components;

public class BlogPostCardViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(BlogPostCardViewModel PostInfo) => View(PostInfo);
}