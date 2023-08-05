using Microsoft.AspNetCore.Mvc;
using QuestionsWeb.Models;
using QuestionsWeb.Services.Interfaces;

namespace QuestionsWeb.WebAPI.Controllers;

[ApiController]
[Route("api/persons")]
public class PersonsApiController : ControllerBase
{
    private readonly IPersonsStore _PersonsStore;

    public PersonsApiController(IPersonsStore PersonsStore)
    {
        _PersonsStore = PersonsStore;
    }

    //[HttpGet] // GET -> api/persons
    //[HttpGet("all")] // GET -> api/persons/all
    //public IActionResult GetAll()
    //{
    //    var persons = _PersonsStore.GetAll();

    //    return Ok(persons);
    //}

    [HttpGet]
    public IEnumerable<Person> GetAll() => _PersonsStore.GetAll();

    [HttpGet("{Id}")]
    public IActionResult GetById(int Id)
    {
        var person = _PersonsStore.GetById(Id);
        if (person is null)
            return NotFound(new { Message = $"Person with id: {Id} not exists", Id });
        return Ok(person);
    }
}