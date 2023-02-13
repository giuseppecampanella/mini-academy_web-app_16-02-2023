using NetAcademy.Domain.Models.DTOs;
using NetAcademy.Repository.Interfaces;

namespace NetAcademy.Services;

public class CountriesService
{
    private readonly ICountriesRepository countryRepository;

    public CountriesService(ICountriesRepository countryRepository)
    {
        this.countryRepository = countryRepository;
    }

    public async Task CreateNewCountryAsync(CountryDto dto)
    {
        await countryRepository.CreateNewCountryAsync(dto);
    }

    public async Task UpdateCountryAsync(string id, CountryDto dto)
    {
        await countryRepository.UpdateCountryAsync(id, dto);
    }

    public async Task<List<CountryDto>> GetAllCountriesAsync()
    {
        return await countryRepository.GetAllCountriesAsync();
    }

    public async Task<CountryDto?> GetCountryAsync(string id)
    {
        return await countryRepository.GetCountryAsync(id);
    }

    public async Task DeleteCountryAsync(string id)
    {
        await countryRepository.DeleteCountryAsync(id);
    }
}