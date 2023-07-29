using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuestionsWeb.Domain.Entities.Identity;
using QuestionsWeb.Services.Interfaces;

namespace QuestionsWeb.Controllers;

[Authorize]
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

    [Authorize(Roles = Role.Adinistrators)]
    //[Authorize(Roles = "Users,Administrators")]
    public IActionResult Delete(int id)
    {
        var person = _PersonsStore.GetById(id);

        if (person == null)
            return NotFound();

        return View(person);
    }

    [HttpPost]
    [Authorize(Roles = Role.Adinistrators)]
    public IActionResult DeleteConfirm(int id)
    {
        var person = _PersonsStore.GetById(id);

        if (person == null)
            return NotFound();

        _PersonsStore.Delete(id);

        return RedirectToAction("Index");
    }
}
