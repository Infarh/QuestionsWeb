using System.Net;
using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using QuestionsWeb.Models;
using QuestionsWeb.Services.Interfaces;

namespace QuestionsWeb.WebAPI.Clients;

public class PersonsApiClient : IPersonsStore
{
    private readonly HttpClient _Client;
    private readonly ILogger<PersonsApiClient> _Logger;

    public PersonsApiClient(HttpClient Client, ILogger<PersonsApiClient> Logger)
    {
        _Client = Client;
        _Logger = Logger;
    }


    public IEnumerable<Person> GetAll()
    {
        var persons = _Client.GetFromJsonAsync<IEnumerable<Person>>("api/persons").Result;
        return persons ?? throw new InvalidOperationException("Не удалось получить данные от WebAPI");
    }

    public Person? GetById(int Id)
    {
        var response = _Client.GetAsync($"api/persons/{Id}").Result;

        if (response.StatusCode == HttpStatusCode.NotFound)
            return null;

        var person = response.EnsureSuccessStatusCode()
            .Content
            .ReadFromJsonAsync<Person>()
            .Result;

        return person;
    }

    public Person? Delete(int Id)
    {
        var response = _Client.DeleteAsync($"api/persons/{Id}").Result;

        if (response.StatusCode == HttpStatusCode.NotFound)
            return null;

        var person = response.EnsureSuccessStatusCode()
            .Content
            .ReadFromJsonAsync<Person>()
            .Result;

        return person;
    }
}
