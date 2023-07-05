namespace QuestionsWeb.Domain.Entities;

public class BlogPost
{
    public required int Id { get; set; }

    public required string Title { get; set; }

    public DateTimeOffset Time { get; set; } = DateTimeOffset.Now;

    public required string Text { get; set; }

    public required int CategoryId { get; set; }
}