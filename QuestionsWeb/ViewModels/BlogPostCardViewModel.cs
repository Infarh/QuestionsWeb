namespace QuestionsWeb.ViewModels;

public class BlogPostCardViewModel
{
    public required int Id { get; set; }

    public required string Title { get; set; }

    public required string Abstract { get; set; }

    public required string CategoryName { get; set; }

    public required DateTimeOffset Date { get; set; }

    public required string ImageUrl { get; set; }
}
