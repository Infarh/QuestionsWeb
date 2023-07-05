using QuestionsWeb.Models;

namespace QuestionsWeb.Services.Interfaces;

public interface IPersonsStore
{
    IEnumerable<Person> GetAll();

    Person? GetById(int Id);

    Person? Delete(int id);
}
