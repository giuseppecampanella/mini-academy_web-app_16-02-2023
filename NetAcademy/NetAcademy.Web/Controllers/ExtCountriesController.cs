using Microsoft.AspNetCore.Mvc;
using NetAcademy.Domain.Models.DTOs;
using NetAcademy.Services;

namespace NetAcademy.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class ExtCountriesController : ControllerBase
{
    private readonly ILogger<ExtCountriesController> logger;
    private readonly ExtCountriesService concessionService;
    private readonly ExcelService excelService;
    public ExtCountriesController(ILogger<ExtCountriesController> log, ExtCountriesService concessionService, ExcelService excelService)
    {
        logger = log;
        this.concessionService = concessionService;
        this.excelService = excelService;
    }

    [HttpGet("{id}")]
    public async Task<ExtCountryDto?> GetExtCountryAsync(string id)
    {
        return await concessionService.GetExtCountryAsync(id);
    }

    [HttpPut("{id}")]
    public async Task UpdateExtCountryAsync(string id, [FromBody] ExtCountryDto dto)
    {
        await concessionService.UpdateExtCountryAsync(id, dto);
    }

    [HttpDelete("{id}")]
    public async Task DeleteExtCountryAsync(string id)
    {
        await concessionService.DeleteExtCountryAsync(id);
    }

    [HttpPost("")]
    public async Task CreateNewExtCountryAsync(ExtCountryDto dto)
    {
        await concessionService.CreateNewExtCountryAsync(dto);
    }

    [HttpGet("")]
    public async Task<List<ExtCountryDto>> GetAllExtCountriesAsync()
    {
        return await concessionService.GetAllExtCountriesAsync();
    }

    [HttpGet("load")]
    public async Task LoadAllExtCountriesAsync()
    {
        await excelService.LoadAllExtCountriesAsync();
    }
}