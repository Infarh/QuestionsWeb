using QuestionsWeb.Domain.Entities;

namespace QuestionsWeb.Services.Interfaces;

public interface IBlogsData
{
    IEnumerable<BlogCategory> GetCategories();

    IEnumerable<BlogPost> GetPosts();
}
