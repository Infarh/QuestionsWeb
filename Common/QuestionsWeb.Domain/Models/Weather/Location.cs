using System.Text.Json.Serialization;

namespace QuestionsWeb.Domain.Models.Weather;

public class Location
{
    [JsonPropertyName("name")] 
    public string Name { get; set; }
    
    [JsonPropertyName("region")] 
    public string Region { get; set; }
    
    [JsonPropertyName("country")] 
    public string Country { get; set; }
    
    [JsonPropertyName("lat")] 
    public float Lat { get; set; }
    
    [JsonPropertyName("lon")] 
    public float Lon { get; set; }
    
    [JsonPropertyName("tz_id")] 
    public string TzId { get; set; }
    
    [JsonPropertyName("localtime_epoch")] 
    public int LocaltimeEpoch { get; set; }
    
    [JsonPropertyName("localtime")] 
    public string Localtime { get; set; }
}