namespace QuestionsWeb.Domain.Entities;

/// <summary> Share method. </summary>
internal class ShareSource
{
    /// <summary> Shared link. </summary>
    public required string Link { get; set; }

    /// <summary>
    /// Share short name.
    /// Ex: Facebook => Fb.
    /// </summary>
    public string? ShortName { get; set; }

    /// <summary> Social media icon. </summary>
    public required string Icon { get; set; }
}