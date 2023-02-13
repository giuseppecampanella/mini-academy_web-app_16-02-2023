using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NetAcademy.Domain.Models.DTOs;
using NetAcademy.Repositories;
using NetAcademy.Repositories.Extensions;
using NetAcademy.Repositories.SqlModels;
using NetAcademy.Repository.Interfaces;

namespace NetAcademy.Repository.Implementations;

public class ConcessionsSqlDatabaseRepository : IConcessionsRepository
{
    private ILogger<ConcessionsSqlDatabaseRepository> logger;
    private XwareContext context;

    public ConcessionsSqlDatabaseRepository(ILogger<ConcessionsSqlDatabaseRepository> l, XwareContext c)
    {
        logger = l;
        context = c;
    }

    public async Task CreateNewConcessionsAsync(List<ConcessionDto> dto)
    {
        await context.Concessions.AddRangeAsync(dto.Select(c => c.ToSqlModel()).ToList());
        await context.SaveChangesAsync();
    }

    public async Task CreateNewConcessionAsync(ConcessionDto dto)
    {
        await context.Concessions.AddAsync(dto.ToSqlModel());
        await context.SaveChangesAsync();
    }

    public async Task DeleteConcessionAsync(string id)
    {
        Concession? concession = await context.Concessions.FindAsync(id);

        if (concession is not null)
        {
            context.Concessions.Remove(concession);
            await context.SaveChangesAsync();
        }
    }

    public async Task DeleteConcessionByCountryIdAsync(string countryId)
    {
        await context.CountryConcessions
            .Where(ecc => ecc.Country.CountryId == countryId)
            .ForEachAsync(ecc => context.CountryConcessions.Remove(ecc));

        //var items = (from countriesConcession in context.CountryConcessions                  
        //             where countriesConcession.CountryId == countryId
        //             select countriesConcession).ToList();
        //items.ForEach(c => context.CountryConcessions.Remove(c));

        await context.SaveChangesAsync();
    }

    public async Task<List<ConcessionDto>> GetAllConcessionsAsync()
    {
        return context.Concessions.Select(c => c.ToDto()).ToList();
    }

    public async Task<ConcessionDto?> GetConcessionAsync(string id)
    {
        Concession? concession = await context.Concessions.FindAsync(id);

        if (concession is not null)
        {
            return concession.ToDto();
        }

        return null;
    }

    public async Task UpdateConcessionAsync(string id, ConcessionDto dto)
    {
        Concession? concession = await context.Concessions.FindAsync(id);

        if (concession is not null)
        {
            concession.ConcessionName = dto.ConcessionName;
            await context.SaveChangesAsync();
        }
    }

    public async Task AssociateConcessionToCountry(AssociateConcessionDto dto)
    {
        CountryConcession countryConcession = new() { ConcessionId = dto.ConcessionId, CountryId = dto.CountryId };
        await context.CountryConcessions.AddAsync(countryConcession);

        //or
        //Concession? concession = await context.Concessions.Include(c => c.Country).FirstOrDefaultAsync(c => c.ConcessionId == dto.ConcessionId);
        //if(concession is not null && concession.Country is null)
        //{
        //    concession.Country = new() { CountryId = dto.CountryId, ConcessionId = dto.ConcessionId };
        //}

        //or
        //Country country = await context.countries.FindAsync(dto.CountryId);
        //country.Concessions.Add(new() { ConcessionId = dto.ConcessionId, CountryId = dto.CountryId });

        await context.SaveChangesAsync();
    }
}