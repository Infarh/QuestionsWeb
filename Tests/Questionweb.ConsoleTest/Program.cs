using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;

using Questionweb.ConsoleTest;

var configuration = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

var client = new HttpClient
{
    BaseAddress = new("http://api.weatherapi.com"),
    DefaultRequestHeaders =
    {
        { "key", configuration["WeatherAPIKey"] }
    }
};

var weather = await client.GetFromJsonAsync<WeatherInfo>("/v1/current.json?q=London");


// {"location":{"name":"London","region":"City of London, Greater London","country":"United Kingdom","lat":51.52,"lon":-0.11,"tz_id":"Europe/London","localtime_epoch":1691238269,"localtime":"2023-08-05 13:24"},"current":{"last_updated_epoch":1691237700,"last_updated":"2023-08-05 13:15","temp_c":15.0,"temp_f":59.0,"is_day":1,"condition":{"text":"Torrential rain shower","icon":"//cdn.weatherapi.com/weather/64x64/day/359.png","code":1246},"wind_mph":10.5,"wind_kph":16.9,"wind_degree":140,"wind_dir":"SE","pressure_mb":1002.0,"pressure_in":29.59,"precip_mm":0.3,"precip_in":0.01,"humidity":94,"cloud":75,"feelslike_c":13.1,"feelslike_f":55.7,"vis_km":3.0,"vis_miles":1.0,"uv":4.0,"gust_mph":21.5,"gust_kph":34.6}}



Console.WriteLine("End.");
