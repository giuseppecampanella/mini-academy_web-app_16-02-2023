using System.ComponentModel.DataAnnotations;

namespace NetAcademy.Repositories.SqlModels;

internal class ExtCountry
{
    internal ExtCountry()
    {
        this.Concessions = new HashSet<ExtCountryConcession>();
    }

    [Key]
    public string CountryId { get; set; } = null!;
    public string CountryName { get; set; } = null!;
    //public string CountryCode { get; set; } = null!;

    public virtual ICollection<ExtCountryConcession> Concessions { get; set; } = null!;
}