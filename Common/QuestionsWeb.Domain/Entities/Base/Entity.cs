using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuestionsWeb.Domain.Entities.Base;

/// <summary>Сущность</summary>
public abstract class Entity
{
    /// <summary>Идентификатор</summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public required int Id { get; set; }
}
