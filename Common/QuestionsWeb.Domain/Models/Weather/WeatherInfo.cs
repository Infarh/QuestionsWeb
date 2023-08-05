using System.Text.Json.Serialization;

namespace QuestionsWeb.Domain.Models.Weather;

public class WeatherInfo
{
    [JsonPropertyName("location")] 
    public Location Location { get; set; }
    
    [JsonPropertyName("current")] 
    public CurrentWeatherInfo Current { get; set; }
}