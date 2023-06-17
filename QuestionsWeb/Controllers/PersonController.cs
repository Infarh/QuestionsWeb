using Microsoft.AspNetCore.Mvc;
using QuestionsWeb.Models;

namespace QuestionsWeb.Controllers;

public class PersonController : Controller
{
    private static List<Person> __Persons = new()
    {
        new() { Id = 1, LastName = "Иванов", Name = "Иван" },
        new() { Id = 2, LastName = "Петров", Name = "Пётр" },
        new() { Id = 3, LastName = "Сидоров", Name = "Сидор" },
    };

    public IActionResult Index()
    {
        return View(__Persons);
    }

    public IActionResult Details(int id)
    {
        var person = __Persons.FirstOrDefault(x => x.Id == id);

        if (person == null)
            return NotFound();

        return View(person);
    }

    //public IActionResult Create()
    //{

    //}

    //public IActionResult Edit(int id)
    //{

    //}

    //public IActionResult Delete(int id)
    //{

    //}
}
