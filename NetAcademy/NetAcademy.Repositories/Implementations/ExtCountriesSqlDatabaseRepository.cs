using Microsoft.Extensions.Logging;
using NetAcademy.Domain.Models.DTOs;
using NetAcademy.Repositories;
using NetAcademy.Repositories.Extensions;
using NetAcademy.Repositories.SqlModels;
using NetAcademy.Repository.Interfaces;

namespace NetAcademy.Repository.Implementations;

public class ExtCountriesSqlDatabaseRepository : IExtCountriesRepository
{
    private ILogger<ExtCountriesSqlDatabaseRepository> logger;
    private XwareContext context;

    public ExtCountriesSqlDatabaseRepository(ILogger<ExtCountriesSqlDatabaseRepository> l, XwareContext c)
    {
        logger = l;
        context = c;
    }

    public async Task CreateNewExtCountriesAsync(List<ExtCountryDto> extCountries)
    {
        await context.ExtCountries.AddRangeAsync(extCountries.Select(c => c.ToSqlModel()).ToList());
        await context.SaveChangesAsync();
    }

    public async Task CreateNewExtCountryAsync(ExtCountryDto extCountry)
    {
        await context.ExtCountries.AddAsync(extCountry.ToSqlModel());
        await context.SaveChangesAsync();
    }

    public async Task DeleteExtCountryAsync(string id)
    {
        ExtCountry? extCountry = await context.ExtCountries.FindAsync(id);

        if (extCountry is not null)
        {
            context.ExtCountries.Remove(extCountry);
            await context.SaveChangesAsync();
        }
    }

    public async Task<List<ExtCountryDto>> GetAllExtCountriesAsync()
    {
        return context.ExtCountries.Select(c => c.ToDto()).ToList();
    }

    public async Task<ExtCountryDto?> GetExtCountryAsync(string id)
    {
        ExtCountry? extCountry = await context.ExtCountries.FindAsync(id);

        if (extCountry is not null)
        {
            return extCountry.ToDto();
        }

        return null;
    }

    public async Task UpdateExtCountryAsync(string id, ExtCountryDto dto)
    {
        ExtCountry? extCountry = await context.ExtCountries.FindAsync(id);

        if (extCountry is not null)
        {
            extCountry.CountryName = dto.CountryName;
            //extCountry.CountryCode = dto.CountryCode;

            await context.SaveChangesAsync();
        }
    }
}