using NetAcademy.Domain.Models.DTOs;

namespace NetAcademy.Repository.Interfaces;

public interface IExtCountriesRepository
{
    public Task<List<ExtCountryDto>> GetAllExtCountriesAsync();
    public Task<ExtCountryDto?> GetExtCountryAsync(string id);
    public Task CreateNewExtCountryAsync(ExtCountryDto extCountry);
    public Task CreateNewExtCountriesAsync(List<ExtCountryDto> extCountries);
    public Task DeleteExtCountryAsync(string id);
    public Task UpdateExtCountryAsync(string id, ExtCountryDto dto);
}