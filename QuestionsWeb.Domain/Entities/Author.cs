using System.ComponentModel.DataAnnotations.Schema;
using QuestionsWeb.Domain.Entities.Base;

namespace QuestionsWeb.Domain.Entities;

public class Author : NamedEntity
{
    [InverseProperty(nameof(BlogPost.Author))]
    public ICollection<BlogPost> Posts { get; set; } = new HashSet<BlogPost>();
}