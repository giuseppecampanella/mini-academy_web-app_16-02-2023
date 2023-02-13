namespace NetAcademy.Repositories.SqlModels;

internal class CountryConcession
{
    public string CountryId { get; set; }
    public string ConcessionId { get; set; }
    public virtual Country Country { get; set; } = null!;
    public virtual Concession Concession { get; set; } = null!;
}