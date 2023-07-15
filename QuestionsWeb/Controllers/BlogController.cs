using Microsoft.AspNetCore.Mvc;
using QuestionsWeb.Services.Interfaces;
using QuestionsWeb.ViewModels;

namespace QuestionsWeb.Controllers;

public class BlogController : Controller
{
    private readonly IBlogsData _BlogData;
    private readonly ILogger<BlogController> _Logger;

    public BlogController(IBlogsData BlogData, ILogger<BlogController> Logger)
    {
        _BlogData = BlogData;
        _Logger = Logger;
    }

    public IActionResult Index(/*[FromServices] IBlogsData BlogData*/)
    {
        var blog_posts = _BlogData.GetPosts();

        var infos = blog_posts.Select(post => new BlogPostCardViewModel
        {
            Id = post.Id,
            Title = post.Title,
            Date = post.Date,
            CategoryName = _BlogData.GetCategoryName(post.CategoryId),
            ImageUrl = post.PreviewImage,
            Abstract = post.AbstractText
        });

        return View(infos);
    }

    public IActionResult Details(int Id) => View();
}
