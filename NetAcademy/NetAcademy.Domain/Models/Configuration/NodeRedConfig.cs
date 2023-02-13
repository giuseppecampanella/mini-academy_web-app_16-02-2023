namespace NetAcademy.Domain.Models.Configuration;

public class NodeRedConfig
{
    public string ConcessionsUrl { get; set; } = null!;
    public Uri ConcessionsUri => new Uri(ConcessionsUrl, UriKind.Relative);
    public string CountriesUrl { get; set; } = null!;
    public Uri CountriesUri => new Uri(CountriesUrl, UriKind.Relative);
    public string CountriesV2Url { get; set; } = null!;
    public Uri CountriesV2Uri => new Uri(CountriesV2Url, UriKind.Relative);
}
