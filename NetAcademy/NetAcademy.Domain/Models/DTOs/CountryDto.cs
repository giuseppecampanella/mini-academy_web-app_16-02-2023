using System.Text.Json.Serialization;

namespace NetAcademy.Domain.Models.DTOs;

public class CountryDto
{
    [JsonPropertyName("country_id")]
    public string CountryId { get; set; } = null!;
    [JsonPropertyName("country_name")]
    public string CountryName { get; set; } = null!;
    //[JsonPropertyName("country_code")]
    //public string CountryCode { get; set; } = null!;
}
