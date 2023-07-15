using Microsoft.AspNetCore.Mvc;
using QuestionsWeb.Services.Interfaces;
using QuestionsWeb.ViewModels;

namespace QuestionsWeb.Components;

public class BlogsCategoriesViewComponent : ViewComponent
{
    private readonly IBlogsData _BlogsData;
    private readonly ILogger<BlogsCategoriesViewComponent> _Logger;

    public BlogsCategoriesViewComponent(IBlogsData BlogsData, ILogger<BlogsCategoriesViewComponent> Logger)
    {
        _BlogsData = BlogsData;
        _Logger = Logger;
    }

    public IViewComponentResult Invoke()
    {
        var categories = GetCategories();
        return View(categories);
    }

    private IEnumerable<BlogsCategoryViewModel> GetCategories() =>
        _BlogsData.GetCategories()
            .Select(c => new BlogsCategoryViewModel
            {
                Id = c.Id,
                Name = c.Name,
            });

    //public async Task<IViewComponentResult> InvokeAsync() => View();
}