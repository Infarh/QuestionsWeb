using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using QuestionsWeb.Domain.Entities.Base;

namespace QuestionsWeb.Domain.Entities;

/// <summary> Blog post. </summary>
public class BlogPost : Entity
{
    /// <summary> Category id. </summary>
    public required int CategoryId { get; set; }

    /// <summary> Category </summary>
    [ForeignKey(nameof(CategoryId))]
    public BlogCategory Category { get; set; }

    /// <summary> Post author Id </summary>
    public required int AuthorId { get; set; }

    /// <summary> Post author </summary>
    public Author Author { get; set; }

    /// <summary> Post title. </summary>
    [MaxLength(255)]
    public required string Title { get; set; }

    /// <summary> Creation date. </summary>
    public DateTimeOffset Date { get; set; } = DateTimeOffset.Now;

    /// <summary> Update date. </summary>
    public DateTimeOffset? DateUpdate { get; set; }

    /// <summary> Post main image. </summary>
    [MaxLength(500)]
    public required string MainImage { get; set; }

    /// <summary> Post content. </summary>
    [MaxLength(10000)]
    public required string Content { get; set; }

    /// <summary> Abstract text. </summary>
    [MaxLength(500)]
    public required string AbstractText { get; set; }

    /// <summary> Tags. </summary>
    public List<Tag> Tags { get; set; }

    /// <summary>Post reviews. </summary>
    public List<Review>? Reviews { get; set; }

    /// <summary> Preview image. </summary>
    [MaxLength(500)]
    public required string PreviewImage { get; set; }
}