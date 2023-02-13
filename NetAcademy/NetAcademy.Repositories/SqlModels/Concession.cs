using System.ComponentModel.DataAnnotations;

namespace NetAcademy.Repositories.SqlModels;

internal class Concession
{
    [Key]
    public string ConcessionId { get; set; } = null!;
    public string ConcessionName { get; set; } = null!;

    public virtual CountryConcession Country { get; set; } = null!;

}