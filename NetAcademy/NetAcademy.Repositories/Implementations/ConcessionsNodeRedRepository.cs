using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NetAcademy.Domain.Models.Configuration;
using NetAcademy.Domain.Models.DTOs;
using NetAcademy.Repositories.Implementations;
using NetAcademy.Repository.Interfaces;

namespace NetAcademy.Repository.Implementations;

public class ConcessionsNodeRedRepository : BaseWebRepository, IConcessionsRepository
{
    private ILogger<ConcessionsNodeRedRepository> logger;
    private readonly NodeRedConfig nodeRedConfig;

    public ConcessionsNodeRedRepository(ILogger<ConcessionsNodeRedRepository> l, IOptions<NodeRedConfig> nodeRedConfig, IHttpClientFactory httpClientFactory, Uri host) : base(httpClientFactory, host)
    {
        logger = l;
        this.nodeRedConfig = nodeRedConfig.Value;
    }

    public virtual async Task<List<ConcessionDto>> GetAllConcessionsAsync()
    {
        Dictionary<string, string> dict = new();
        return (await base.DoGet<List<ConcessionDto>>(nodeRedConfig.ConcessionsUri, dict)).Result;
    }

    public Task CreateNewConcessionAsync(ConcessionDto concession)
    {
        throw new NotImplementedException();
    }

    public Task DeleteConcessionAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<ConcessionDto?> GetConcessionAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateConcessionAsync(string id, ConcessionDto dto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteConcessionByCountryIdAsync(string countryId)
    {
        throw new NotImplementedException();
    }

    public Task CreateNewConcessionsAsync(List<ConcessionDto> concessions)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAllConcessionsAsync()
    {
        throw new NotImplementedException();
    }

    public Task AssociateConcessionToCountry(AssociateConcessionDto dto)
    {
        throw new NotImplementedException();
    }
}