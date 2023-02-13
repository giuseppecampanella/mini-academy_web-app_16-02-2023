using System.ComponentModel.DataAnnotations;

namespace NetAcademy.Repositories.SqlModels;

internal class Country
{
    internal Country()
    {
        this.Concessions = new HashSet<CountryConcession>();
    }

    [Key]
    public string CountryId { get; set; } = null!;
    public string CountryName { get; set; } = null!;
    //public string CountryCode { get; set; } = null!;

    public virtual ICollection<CountryConcession> Concessions { get; set; } = null!;
}