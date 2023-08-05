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


    public async Task<IEnumerable<Person>> GetAll()
    {
        var persons =  await _Client.GetFromJsonAsync<IEnumerable<Person>>("api/persons");
        return persons ?? throw new InvalidOperationException("Не удалось получить данные от WebAPI");
    }

    public async Task<Person?> GetById(int Id)
    {
        var response = await _Client.GetAsync($"api/persons/{Id}");

        if (response.StatusCode == HttpStatusCode.NotFound)
            return null;

        var person = response.EnsureSuccessStatusCode()
            .Content
            .ReadFromJsonAsync<Person>()
            .Result;

        return person;
    }

    public async Task<Person?> Delete(int Id)
    {
        var response = await _Client.DeleteAsync($"api/persons/{Id}");

        if (response.StatusCode == HttpStatusCode.NotFound)
            return null;

        var person = response.EnsureSuccessStatusCode()
            .Content
            .ReadFromJsonAsync<Person>()
            .Result;

        return person;
    }
}
