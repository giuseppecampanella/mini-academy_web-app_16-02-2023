using Microsoft.Extensions.Logging;
using NetAcademy.Domain.Models.DTOs;
using NetAcademy.Repositories;
using NetAcademy.Repositories.Extensions;
using NetAcademy.Repositories.SqlModels;
using NetAcademy.Repository.Interfaces;

namespace NetAcademy.Repository.Implementations;

public class CountriesSqlDatabaseRepository : ICountriesRepository
{
    private ILogger<CountriesSqlDatabaseRepository> logger;
    private XwareContext context;

    public CountriesSqlDatabaseRepository(ILogger<CountriesSqlDatabaseRepository> l, XwareContext c)
    {
        logger = l;
        context = c;
    }

    public async Task CreateNewCountriesAsync(List<CountryDto> countries)
    {
        await context.Countries.AddRangeAsync(countries.Select(c => c.ToSqlModel()).ToList());
        await context.SaveChangesAsync();
    }

    public async Task CreateNewCountryAsync(CountryDto country)
    {
        await context.Countries.AddAsync(country.ToSqlModel());
        await context.SaveChangesAsync();
    }

    public async Task DeleteCountryAsync(string id)
    {
        Country? country = await context.Countries.FindAsync(id);

        if (country is not null)
        {
            context.Countries.Remove(country);
            await context.SaveChangesAsync();
        }
    }

    public async Task<List<CountryDto>> GetAllCountriesAsync()
    {
        return context.Countries.Select(c => c.ToDto()).ToList();
    }

    public async Task<CountryDto?> GetCountryAsync(string id)
    {
        Country? country = await context.Countries.FindAsync(id);

        if (country is not null)
        {
            return country.ToDto();
        }

        return null;
    }

    public async Task UpdateCountryAsync(string id, CountryDto dto)
    {
        Country? country = await context.Countries.FindAsync(id);

        if (country is not null)
        {
            country.CountryName = dto.CountryName;
            //country.CountryCode = dto.CountryCode;

            await context.SaveChangesAsync();
        }
    }
}