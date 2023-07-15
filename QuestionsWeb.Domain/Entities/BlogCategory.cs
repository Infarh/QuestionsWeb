using QuestionsWeb.Domain.Entities.Base;

namespace QuestionsWeb.Domain.Entities;

/// <summary> Blog category. </summary>
public class BlogCategory : NamedEntity
{
    /// <summary> Parent id. </summary>
    public int? ParentId { get; set; }
}