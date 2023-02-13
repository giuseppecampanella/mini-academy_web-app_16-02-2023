using NetAcademy.Domain.Models.DTOs;
using NetAcademy.Repository.Interfaces;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.XWPF.UserModel;

namespace NetAcademy.Services;

public class ExcelService
{
    private readonly IConcessionsRepository concessionsRepository;
    private readonly IExtCountriesRepository extCountriesRepository;

    public ExcelService(IConcessionsRepository concessionsRepository, IExtCountriesRepository extCountriesRepository)
    {
        this.concessionsRepository = concessionsRepository;
        this.extCountriesRepository = extCountriesRepository;
    }

    // Exercise
    public async Task LoadAllConcessionsAsync()
    {
        // TODO: leggere le concessions da file excel e salvare tutto su db
    }

    // Exercise
    public async Task LoadAllExtCountriesAsync()
    {
        // TODO: leggere le extCountry da file excel e salvare tutto su db
    }

    // Exercise
    public async Task SaveConcessionsToExcelAsync(Stream writingStream)
    {
        // TODO: leggere le concessioni da db e salvare tutto su un file excel
    }

    // Exercise
    public async Task SaveConcessionsAndExtCountriesToExcel(Stream writingStream)
    {
        // TODO salvare concessions e countries che si trovano dentro la tabella ExtCountryConcession
    }

}