using System.Text.Json.Serialization;

namespace NetAcademy.Domain.Models.DTOs;

public class ConcessionDto
{
    [JsonPropertyName("concession_id")]
    public string ConcessionId { get; set; } = null!;
    [JsonPropertyName("concession_name")]
    public string ConcessionName { get; set; } = null!;
}
