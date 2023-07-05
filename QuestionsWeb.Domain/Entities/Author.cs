using QuestionsWeb.Domain.Entities.Base;

namespace QuestionsWeb.Domain.Entities;

public class Author : Entity
{
    public required string Name { get; set; }
}