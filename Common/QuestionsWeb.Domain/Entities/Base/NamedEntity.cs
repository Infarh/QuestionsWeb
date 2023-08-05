using Microsoft.EntityFrameworkCore;

namespace QuestionsWeb.Domain.Entities.Base;

/// <summary>Именованная сущность</summary>
[Index(nameof(Name), IsUnique = true)]
public abstract class NamedEntity : Entity
{
    /// <summary>Имя</summary>
    //[Required]
    public required string Name { get; set; }
}
