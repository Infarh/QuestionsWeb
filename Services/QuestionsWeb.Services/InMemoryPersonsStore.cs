using QuestionsWeb.Models;
using QuestionsWeb.Services.Interfaces;

namespace QuestionsWeb.Services;

public class InMemoryPersonsStore : IPersonsStore, IDisposable
{
    private List<Person> _Persons = new()
    {
        new() { Id = 1, LastName = "Иванов", Name = "Иван" },
        new() { Id = 2, LastName = "Петров", Name = "Пётр" },
        new() { Id = 3, LastName = "Сидоров", Name = "Сидор" },
    };

    public Task<IEnumerable<Person>> GetAll() => Task.FromResult(_Persons.AsEnumerable());

    public Task<Person?> GetById(int Id)
    {
        var person = _Persons.FirstOrDefault(x => x.Id == Id);

        return Task.FromResult(person);
    }

    public async Task<Person?> Delete(int id)
    {
        var person = await GetById(id);

        if (person is null)
            return null;

        _Persons.Remove(person);

        return person;
    }

    public void Dispose()
    {

    }
}
