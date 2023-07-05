using QuestionsWeb.Data;
using QuestionsWeb.Domain.Entities;
using QuestionsWeb.Services.Interfaces;

namespace QuestionsWeb.Services;

public class InMemoryBlogsData : IBlogsData
{
    public IEnumerable<BlogCategory> GetCategories() => TestData.Categories;

    public IEnumerable<BlogPost> GetPosts() => TestData.Posts;
}
