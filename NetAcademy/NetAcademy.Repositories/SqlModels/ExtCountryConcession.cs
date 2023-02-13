namespace NetAcademy.Repositories.SqlModels;

internal class ExtCountryConcession
{
    public string CountryId { get; set; }
    public string ConcessionId { get; set; }
    public virtual ExtCountry ExtCountry { get; set; } = null!;
    public virtual Concession Concession { get; set; } = null!;
}