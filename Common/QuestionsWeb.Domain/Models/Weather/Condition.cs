using System.Text.Json.Serialization;

namespace QuestionsWeb.Domain.Models.Weather;

public class Condition
{
    [JsonPropertyName("text")] 
    public string Text { get; set; }
    
    [JsonPropertyName("icon")] 
    public string Icon { get; set; }
    
    [JsonPropertyName("code")] 
    public int Code { get; set; }
}