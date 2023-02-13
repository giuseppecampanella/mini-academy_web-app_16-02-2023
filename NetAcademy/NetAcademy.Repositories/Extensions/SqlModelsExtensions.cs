using NetAcademy.Domain.Models.DTOs;
using NetAcademy.Repositories.SqlModels;

namespace NetAcademy.Repositories.Extensions
{
    internal static class SqlModelsExtensions
    {

        public static ExtCountry? ToSqlModel(this ExtCountryDto e)
        {
            if (e == null) return null;
            return new()
            {
                CountryId = e.CountryId,
                CountryName = e.CountryName,
                //CountryCode = e.CountryCode
            };
        }

        public static ExtCountryDto? ToDto(this ExtCountry e)
        {
            if (e == null) return null;
            return new()
            {
                CountryId = e.CountryId,
                CountryName = e.CountryName,
                //CountryCode = e.CountryCode
            };
        }

        public static Concession? ToSqlModel(this ConcessionDto c)
        {
            if (c == null) return null;
            return new()
            {
                ConcessionId = c.ConcessionId,
                ConcessionName = c.ConcessionName,
            };
        }

        public static ConcessionDto? ToDto(this Concession c)
        {
            if (c == null) return null;
            return new()
            {
                ConcessionId = c.ConcessionId,
                ConcessionName = c.ConcessionName,
            };
        }
    }
}
