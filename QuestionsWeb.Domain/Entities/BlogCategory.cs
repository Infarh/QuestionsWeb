using QuestionsWeb.Domain.Entities.Base;

namespace QuestionsWeb.Domain.Entities;

public class BlogCategory : Entity
{
    public required string Name { get; set; }

    public int? ParentId { get; set; }
}