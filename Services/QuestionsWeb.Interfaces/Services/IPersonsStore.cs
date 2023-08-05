using QuestionsWeb.Models;

namespace QuestionsWeb.Services.Interfaces;

public interface IPersonsStore
{
    Task<IEnumerable<Person>> GetAll();

    Task<Person?> GetById(int Id);

    Task<Person?> Delete(int id);
}
