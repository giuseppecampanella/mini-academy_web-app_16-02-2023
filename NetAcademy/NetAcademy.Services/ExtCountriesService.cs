using NetAcademy.Domain.Models.DTOs;
using NetAcademy.Repository.Interfaces;

namespace NetAcademy.Services;

public class ExtCountriesService
{
    private readonly IExtCountriesRepository extCountryRepository;

    public ExtCountriesService(IExtCountriesRepository extCountryRepository)
    {
        this.extCountryRepository = extCountryRepository;
    }

    public async Task CreateNewExtCountryAsync(ExtCountryDto dto)
    {
        await extCountryRepository.CreateNewExtCountryAsync(dto);
    }

    public async Task UpdateExtCountryAsync(string id, ExtCountryDto dto)
    {
        await extCountryRepository.UpdateExtCountryAsync(id, dto);
    }

    public async Task<List<ExtCountryDto>> GetAllExtCountriesAsync()
    {
        return await extCountryRepository.GetAllExtCountriesAsync();
    }

    public async Task<ExtCountryDto?> GetExtCountryAsync(string id)
    {
        return await extCountryRepository.GetExtCountryAsync(id);
    }

    public async Task DeleteExtCountryAsync(string id)
    {
        await extCountryRepository.DeleteExtCountryAsync(id);
    }
}