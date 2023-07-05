using QuestionsWeb.Domain.Entities.Base;

namespace QuestionsWeb.Domain.Entities;

public class BlogPost : Entity
{
    public required string Title { get; set; }

    public DateTimeOffset Time { get; set; } = DateTimeOffset.Now;

    public required string AbstractText { get; set; }

    public required string Text { get; set; }

    public required int CategoryId { get; set; }

    public required int AuthorId { get; set; }

    public required string PreviewImage { get; set; }

    public required string MainImage { get; set; }
}