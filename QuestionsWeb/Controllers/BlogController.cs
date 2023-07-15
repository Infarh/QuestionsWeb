using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

using QuestionsWeb.Domain.Entities;
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

    private BlogPostCardViewModel ToViewModel(BlogPost post) => new BlogPostCardViewModel
    {
        Id = post.Id,
        Title = post.Title,
        Date = post.Date,
        CategoryName = _BlogData.GetCategoryName(post.CategoryId),
        ImageUrl = post.PreviewImage,
        Abstract = post.AbstractText
    };

    private IEnumerable<BlogPostCardViewModel> ToViewModel(IEnumerable<BlogPost> posts) => posts.Select(ToViewModel);

    public IActionResult Index(/*[FromServices] IBlogsData BlogData*/)
    {
        var blog_posts = _BlogData.GetPosts();

        var infos = ToViewModel(blog_posts);

        return View(infos);
    }

    public IActionResult Details(int Id)
    {
        var post = _BlogData.GetPostById(Id);

        if (post is null)
            return NotFound();

        var category_name = _BlogData.GetCategoryName(post.CategoryId);

        //ViewBag.CategoryName = category_name;
        ViewData["CategoryName"] = category_name;

        return View(post);
    }

    public IActionResult Category(int Id)
    {
        var blog_posts = _BlogData.GetPostsByCategory(Id);

        var infos = ToViewModel(blog_posts);

        return View("Index", infos);
    }
}
