using QuestionsWeb.Domain.Entities.Base;

namespace QuestionsWeb.Domain.Entities;

public class BlogCategory : NamedEntity
{
    public int? ParentId { get; set; }
}