using QuestionsWeb.Domain.Entities.Base;

namespace QuestionsWeb.Domain.Entities;

/// <summary> Review. </summary>
public abstract class Review : NamedEntity
{
    /// <summary> Review rate. </summary>
    public int Rate { get; set; }

    /// <summary> Author of the review. </summary>
    public required int AuthorId { get; set; }

    /// <summary> Review content/message. </summary>
    public required string Content { get; set; }

    /// <summary> Creation date. </summary>
    public DateTimeOffset Date { get; set; } = DateTimeOffset.Now;

    /// <summary> Type of review. </summary>
    public ReviewType Type { get; set; }

    /// <summary> Is review deleted or no. </summary>
    public bool IsDeleted { get; set; }
}