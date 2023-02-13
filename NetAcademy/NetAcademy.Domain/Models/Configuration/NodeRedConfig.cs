namespace NetAcademy.Domain.Models.Configuration;

public class NodeRedConfig
{
    public string ConcessionsUrl { get; set; } = null!;
    public Uri ConcessionsUri => new Uri(ConcessionsUrl, UriKind.Relative);
    public string ExtCountriesUrl { get; set; } = null!;
    public Uri ExtCountriesUri => new Uri(ExtCountriesUrl, UriKind.Relative);
    public string ExtCountriesV2Url { get; set; } = null!;
    public Uri ExtCountriesV2Uri => new Uri(ExtCountriesV2Url, UriKind.Relative);
}
