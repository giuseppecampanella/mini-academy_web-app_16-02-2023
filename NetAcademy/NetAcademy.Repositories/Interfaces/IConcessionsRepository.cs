using NetAcademy.Domain.Models.DTOs;

namespace NetAcademy.Repository.Interfaces;

public interface IConcessionsRepository
{
    public Task<List<ConcessionDto>> GetAllConcessionsAsync();
    public Task<ConcessionDto?> GetConcessionAsync(string id);
    public Task CreateNewConcessionAsync(ConcessionDto concession);
    public Task CreateNewConcessionsAsync(List<ConcessionDto> concessions);
    public Task DeleteConcessionAsync(string id);
    public Task DeleteConcessionByCountryIdAsync(string countryId);
    public Task UpdateConcessionAsync(string id, ConcessionDto dto);
    public Task AssociateConcessionToCountry(AssociateConcessionDto dto);
}