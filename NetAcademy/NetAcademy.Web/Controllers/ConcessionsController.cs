using Microsoft.AspNetCore.Mvc;
using NetAcademy.Domain.Models.DTOs;
using NetAcademy.Services;

namespace NetAcademy.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class ConcessionsController : ControllerBase
{
    private readonly ILogger<ConcessionsController> logger;
    private readonly ConcessionsService concessionService;
    private readonly ExcelService excelService;
    public ConcessionsController(ILogger<ConcessionsController> log, ConcessionsService concessionService, ExcelService excelService)
    {
        logger = log;
        this.concessionService = concessionService;
        this.excelService = excelService;
    }

    [HttpGet("{id}")]
    public async Task<ConcessionDto?> GetConcessionAsync(string id)
    {
        return await concessionService.GetConcessionAsync(id);
    }

    [HttpPut("{id}")]
    public async Task UpdateConcessionAsync(string id, [FromBody] ConcessionDto dto)
    {
        await concessionService.UpdateConcessionAsync(id, dto);
    }

    [HttpDelete("{id}")]
    public async Task DeleteConcessionAsync(string id)
    {
        await concessionService.DeleteConcessionAsync(id);
    }

    [HttpDelete("country/{countryId}")]
    public async Task DeleteConcessionByCountryIdAsync(string countryId)
    {
        await concessionService.DeleteConcessionByCountryIdAsync(countryId);
    }

    [HttpPost("")]
    public async Task CreateNewConcessionAsync(ConcessionDto dto)
    {
        await concessionService.CreateNewConcessionAsync(dto);
    }

    [HttpGet("")]
    public async Task<List<ConcessionDto>> GetAllConcessionsAsync()
    {
        return await concessionService.GetAllConcessionsAsync();
    }

    [HttpGet("load")]
    public async Task LoadAllConcessionsAsync()
    {
        await excelService.LoadAllConcessionsAsync();
    }

    [HttpPost("associate")]
    public async Task AssociateConcessionToCountry(AssociateConcessionDto dto)
    {
        await concessionService.AssociateConcessionToCountry(dto);
    }

    [HttpGet("file/concession")]
    public async Task<object> SaveConcessionsToExcel()
    {
        using var writingStream = new MemoryStream();
        await excelService.SaveConcessionsToExcelAsync(writingStream);
        return File(writingStream.ToArray(), "application/octet-stream", "concessions.xlsx");
    }

    [HttpGet("file/concession-countries")]
    public async Task<object> SaveConcessionsAndCountriesToExcel()
    {
        using var writingStream = new MemoryStream();
        await excelService.SaveConcessionsAndCountriesToExcel(writingStream);
        return File(writingStream.ToArray(), "application/octet-stream", "concessionsCountries.xlsx");
    }
}