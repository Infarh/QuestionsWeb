using System.ComponentModel.DataAnnotations.Schema;
using QuestionsWeb.Domain.Entities.Base;

namespace QuestionsWeb.Domain.Entities;

/// <summary> Blog category. </summary>
public class BlogCategory : NamedEntity
{
    /// <summary> Parent id. </summary>
    public int? ParentId { get; set; }

    public BlogCategory? Parent { get; set; }

    [InverseProperty(nameof(BlogPost.Category))]
    public ICollection<BlogPost> Posts { get; set; } = new HashSet<BlogPost>();
}