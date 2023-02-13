using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NetAcademy.Domain.Models.DTOs;
using NetAcademy.Repositories;
using NetAcademy.Repositories.SqlModels;
using NetAcademy.Repository.Interfaces;

namespace NetAcademy.Repository.Implementations;

public class ExtCountriesConcessionsRepository : IExtCountriesConcessionsRepository
{
    private ILogger<ExtCountriesConcessionsRepository> logger;
    private XwareContext context;

    public ExtCountriesConcessionsRepository(ILogger<ExtCountriesConcessionsRepository> l, XwareContext c)
    {
        logger = l;
        context = c;
    }

    public async Task<List<ExtCountryConcessionInfoDto>> GetAllAsync()
    {
        List<ExtCountryConcession> values = await context.ExtCountryConcessions.Include(ecc => ecc.Concession).Include(ecc => ecc.ExtCountry).ToListAsync();
        return values.Select(v => new ExtCountryConcessionInfoDto() { ConcessionId = v.ConcessionId, ConcessionName = v.Concession.ConcessionName, CountryId = v.CountryId, CountryName = v.ExtCountry.CountryName }).ToList();
    }
}