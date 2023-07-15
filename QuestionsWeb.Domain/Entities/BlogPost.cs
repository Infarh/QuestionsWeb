using QuestionsWeb.Domain.Entities.Base;

namespace QuestionsWeb.Domain.Entities;

/// <summary> Blog post. </summary>
public class BlogPost : Entity
{

    /// <summary> Category id. </summary>
    public required int CategoryId { get; set; }

    /// <summary> Post author. </summary>
    public required int AuthorId { get; set; }

    /// <summary> Post title. </summary>
    public required string Title { get; set; }

    /// <summary> Creation date. </summary>
    public DateTimeOffset Date { get; set; } = DateTimeOffset.Now;

    /// <summary> Update date. </summary>
    public DateTimeOffset? DateUpdate { get; set; }

    /// <summary> Post main image. </summary>
    public required string MainImage { get; set; }

    /// <summary> Post content. </summary>
    public required string Content { get; set; }

    /// <summary> Abstract text. </summary>
    public required string AbstractText { get; set; }

    /// <summary> Tags. </summary>
    public List<Tag> Tags { get; set; }

    /// <summary>Post reviews. </summary>
    public List<Review>? Reviews { get; set; }

    /// <summary> Preview image. </summary>
    public required string PreviewImage { get; set; }
}