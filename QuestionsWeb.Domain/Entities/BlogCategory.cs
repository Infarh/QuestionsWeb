namespace QuestionsWeb.Domain.Entities;

public class BlogCategory
{
    public required int Id { get; set; }

    public required string Name { get; set; }

    public int? ParentId { get; set; }
}