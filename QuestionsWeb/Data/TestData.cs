using QuestionsWeb.Domain.Entities;

namespace QuestionsWeb.Data;

public static class TestData
{
    static TestData()
    {
        var categories = new BlogCategory[]
        {
            new() { Id = 1, Name = "College", },
            new() { Id = 2, Name = "Gym", },
            new() { Id = 3, Name = "High School", },
            new() { Id = 4, Name = "Primary", },
            new() { Id = 5, Name = "School", },
            new() { Id = 6, Name = "University", },
        };
        Categories = categories;

        var rnd = new Random(10);

        var authors = Enumerable
            .Range(1, 5)
            .Select(id => new Author
            {
                Id = id,
                Name = $"Author-{id}",
            })
            .ToArray();
        Authors = authors;

        Posts = Enumerable
            .Range(1, 50)
            .Select(id => new BlogPost
            {
                Id = id,
                Date = DateTimeOffset.Now.AddDays(rnd.Next(5, 150)),
                Title = $"Blog post {id} title",
                AbstractText = $"Blog post {id} abstract text",
                Content = $"Blog post {id} text QWE",
                PreviewImage = "~/img/blog-list/1.png",
                MainImage = "~/img/blog/blog-single/images.png",
                AuthorId = authors[rnd.Next(authors.Length)].Id,
                CategoryId = categories[rnd.Next(categories.Length)].Id,
            })
            .ToArray();
    }

    public static IEnumerable<BlogCategory> Categories { get; }

    public static IEnumerable<Author> Authors { get; }

    public static IEnumerable<BlogPost> Posts { get; }
}
