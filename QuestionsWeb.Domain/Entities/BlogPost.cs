namespace QuestionsWeb.Domain.Entities;

public class BlogPost
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public DateTimeOffset Time { get; set; } = DateTimeOffset.Now;

    public string Text { get; set; } = null!;


}
