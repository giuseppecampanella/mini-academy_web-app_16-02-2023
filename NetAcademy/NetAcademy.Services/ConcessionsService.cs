using NetAcademy.Domain.Models.DTOs;
using NetAcademy.Repository.Interfaces;

namespace NetAcademy.Services;

public class ConcessionsService
{
    private readonly IConcessionsRepository concessionRepository;

    public ConcessionsService(IConcessionsRepository concessionRepository)
    {
        this.concessionRepository = concessionRepository;
    }

    public async Task CreateNewConcessionAsync(ConcessionDto dto)
    {
        await concessionRepository.CreateNewConcessionAsync(dto);
    }

    public async Task UpdateConcessionAsync(string id, ConcessionDto dto)
    {
        await concessionRepository.UpdateConcessionAsync(id, dto);
    }

    public async Task<List<ConcessionDto>> GetAllConcessionsAsync()
    {
        return await concessionRepository.GetAllConcessionsAsync();
    }

    public async Task<ConcessionDto?> GetConcessionAsync(string id)
    {
        return await concessionRepository.GetConcessionAsync(id);
    }

    public async Task DeleteConcessionAsync(string id)
    {
        await concessionRepository.DeleteConcessionAsync(id);
    }

    public async Task DeleteConcessionByCountryIdAsync(string countryId)
    {
        await concessionRepository.DeleteConcessionByCountryIdAsync(countryId);
    }

    public async Task AssociateConcessionToCountry(AssociateConcessionDto dto)
    {
        await concessionRepository.AssociateConcessionToCountry(dto);
    }
}