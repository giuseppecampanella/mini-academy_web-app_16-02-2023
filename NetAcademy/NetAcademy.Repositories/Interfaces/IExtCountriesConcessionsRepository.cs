using NetAcademy.Domain.Models.DTOs;

namespace NetAcademy.Repository.Interfaces;

public interface IExtCountriesConcessionsRepository
{
    public Task<List<ExtCountryConcessionInfoDto>> GetAllAsync();
}