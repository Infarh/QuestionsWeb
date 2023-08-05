using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using QuestionsWeb.WebAPI.Clients;

var configuration = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

Console.WriteLine("Нажмите Enter для начала");
Console.ReadLine();

var client = new HttpClient
{
    BaseAddress = new("http://localhost:5258/"),

};

var persons_client = new PersonsApiClient(client, new Logger<PersonsApiClient>(new NullLoggerFactory()));

var persons = await persons_client.GetAll();

var deleted_person = await persons_client.Delete(2);

var persons2 = await persons_client.GetAll();


Console.WriteLine("End.");
