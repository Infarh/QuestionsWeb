using QuestionsWeb.Domain.Entities.Base;

namespace QuestionsWeb.Domain.Entities;

/// <summary> Tag. </summary>
public class Tag : NamedEntity
{
    public ICollection<BlogPost> Posts { get; set; } = new HashSet<BlogPost>();
}