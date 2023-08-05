using Microsoft.Extensions.Logging;
using QuestionsWeb.DAL.Context;
using QuestionsWeb.Domain.Entities;
using QuestionsWeb.Services.Interfaces;

namespace QuestionsWeb.Services;

public class DbBlogPostData : IBlogsData
{
    private readonly QuestionsDB _DB;
    private readonly ILogger<DbBlogPostData> _Logger;

    public DbBlogPostData(QuestionsDB db, ILogger<DbBlogPostData> Logger)
    {
        _DB = db;
        _Logger = Logger;
    }

    public IEnumerable<BlogCategory> GetCategories()
    {
        var categories = _DB.BlogCategories.ToArray();
        return categories;
    }

    public IEnumerable<BlogPost> GetPosts()
    {
        var posts = _DB.BlogPosts.ToArray();
        return posts;
    }

    public string GetCategoryName(int CategoryId)
    {
        var category = _DB
            .BlogCategories
            .Select(c => new { c.Id, c.Name })
            .FirstOrDefault(c => c.Id == CategoryId)
            ?.Name;

        if (category is null)
            throw new InvalidOperationException($"Категория с Id:{CategoryId} не найдена");

        return category;
    }

    public BlogPost? GetPostById(int PostId)
    {
        //var post = _DB.BlogPosts.FirstOrDefault(post => post.Id == PostId);
        var post = _DB.BlogPosts.Find(PostId);
        return post;
    }

    public IEnumerable<BlogPost> GetPostsByCategory(int CategoryId)
    {
        var query = _DB.BlogPosts
            .Where(post => post.CategoryId == CategoryId);

        var posts = query.ToArray();

        return posts;
    }
}
