namespace QuestionsWeb.Models;

/// <summary>
/// Информация о человеке
/// </summary>
public class Person
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Имя
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Фамилия
    /// </summary>
    public string? LastName { get; set; }

    /// <summary>
    /// Комментарий
    /// </summary>
    public string? Description { get; set; }
}
