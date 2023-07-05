using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionsWeb.Domain.Entities.Base;

/// <summary>Именованная сущность</summary>
public abstract class NamedEntity : Entity
{
    /// <summary>Имя</summary>
    public required string Name { get; set; }
}
