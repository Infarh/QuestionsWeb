using QuestionsWeb.Data;
using QuestionsWeb.Domain.Entities;
using QuestionsWeb.Services.Interfaces;

namespace QuestionsWeb.Services;

public class InMemoryBlogsData : IBlogsData
{
    public IEnumerable<BlogCategory> GetCategories() => TestData.Categories;

    public IEnumerable<BlogPost> GetPosts() => TestData.Posts;
    public string GetCategoryName(int CategoryId)
    {
        var category = TestData.Categories.FirstOrDefault(c => c.Id == CategoryId);

        if (category is null)
            throw new InvalidOperationException($"Категория с Id:{CategoryId} не найдена");

        return category.Name;
    }

    public BlogPost? GetPostById(int PostId)
    {
        var post = TestData.Posts.FirstOrDefault(post => post.Id == PostId);
        return post;
    }

    public IEnumerable<BlogPost> GetPostsByCategory(int CategoryId)
    {
        var posts = TestData.Posts.Where(post => post.CategoryId == CategoryId);

        return posts;
    }
}
