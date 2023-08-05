using Microsoft.AspNetCore.Mvc;
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

    public IEnumerable<Person> GetAll() => _Persons;

    public Person? GetById(int Id)
    {
        var person = _Persons.FirstOrDefault(x => x.Id == Id);

        return person;
    }

    public Person? Delete(int id)
    {
        var person = GetById(id);

        if (person is null)
            return null;

        _Persons.Remove(person);

        return person;
    }

    public void Dispose()
    {

    }
}
