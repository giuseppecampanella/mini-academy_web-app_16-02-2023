using NetAcademy.Domain.Models.DTOs;

namespace NetAcademy.Repository.Interfaces;

public interface ICountriesRepository
{
    public Task<List<CountryDto>> GetAllCountriesAsync();
    public Task<CountryDto?> GetCountryAsync(string id);
    public Task CreateNewCountryAsync(CountryDto Country);
    public Task CreateNewCountriesAsync(List<CountryDto> Countries);
    public Task DeleteCountryAsync(string id);
    public Task UpdateCountryAsync(string id, CountryDto dto);
}