using Microsoft.AspNetCore.Mvc;
using QuestionsWeb.Models;
using QuestionsWeb.Services.Interfaces;

namespace QuestionsWeb.Controllers;

public class PersonController : Controller
{
    private readonly IPersonsStore _PersonsStore;

    public PersonController(IPersonsStore PersonsStore)
    {
        _PersonsStore = PersonsStore;
    }

    public IActionResult Index()
    {
        var persons = _PersonsStore.GetAll();

        return View(persons);
    }

    public IActionResult Details(int id)
    {
        var person = _PersonsStore.GetById(id);

        if (person == null)
            return NotFound();

        return View(person);
    }

    //public IActionResult Details(int id) => __Persons.FirstOrDefault(x => x.Id == id) is { } person 
    //    ? View(person) 
    //    : NotFound();

    //public IActionResult Create()
    //{

    //}

    //public IActionResult Edit(int id)
    //{

    //}

    public IActionResult Delete(int id)
    {
        var person = _PersonsStore.GetById(id);

        if (person == null)
            return NotFound();

        return View(person);
    }

    [HttpPost]
    public IActionResult DeleteConfirm(int id)
    {
        var person = _PersonsStore.GetById(id);

        if (person == null)
            return NotFound();

        _PersonsStore.Delete(id);

        return RedirectToAction("Index");
    }
}
