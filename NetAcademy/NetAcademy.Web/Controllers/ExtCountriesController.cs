using Microsoft.AspNetCore.Mvc;
using NetAcademy.Domain.Models.DTOs;
using NetAcademy.Services;

namespace NetAcademy.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class CountriesController : ControllerBase
{
    private readonly ILogger<CountriesController> logger;
    private readonly CountriesService concessionService;
    private readonly ExcelService excelService;
    public CountriesController(ILogger<CountriesController> log, CountriesService concessionService, ExcelService excelService)
    {
        logger = log;
        this.concessionService = concessionService;
        this.excelService = excelService;
    }

    [HttpGet("{id}")]
    public async Task<CountryDto?> GetCountryAsync(string id)
    {
        return await concessionService.GetCountryAsync(id);
    }

    [HttpPut("{id}")]
    public async Task UpdateCountryAsync(string id, [FromBody] CountryDto dto)
    {
        await concessionService.UpdateCountryAsync(id, dto);
    }

    [HttpDelete("{id}")]
    public async Task DeleteCountryAsync(string id)
    {
        await concessionService.DeleteCountryAsync(id);
    }

    [HttpPost("")]
    public async Task CreateNewCountryAsync(CountryDto dto)
    {
        await concessionService.CreateNewCountryAsync(dto);
    }

    [HttpGet("")]
    public async Task<List<CountryDto>> GetAllCountriesAsync()
    {
        return await concessionService.GetAllCountriesAsync();
    }

    [HttpGet("load")]
    public async Task LoadAllCountriesAsync()
    {
        await excelService.LoadAllCountriesAsync();
    }
}