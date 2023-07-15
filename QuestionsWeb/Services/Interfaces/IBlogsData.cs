using QuestionsWeb.Domain.Entities;

namespace QuestionsWeb.Services.Interfaces;

public interface IBlogsData
{
    IEnumerable<BlogCategory> GetCategories();

    IEnumerable<BlogPost> GetPosts();

    string GetCategoryName(int CategoryId);

    BlogPost? GetPostById(int PostId);

    IEnumerable<BlogPost> GetPostsByCategory(int CategoryId);
}
