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

    public async Task LoadAllConcessionsAsync()
    {
        List<ConcessionDto> concessions = new();

        XSSFWorkbook xssfwb;
        using (FileStream file = new("Files/data.xlsx", FileMode.Open, FileAccess.Read))
        {
            xssfwb = new XSSFWorkbook(file);
        }

        ISheet sheet = xssfwb.GetSheet("Concessions");
        for (int row = 1; row <= sheet.LastRowNum; row++)
        {
            if (sheet.GetRow(row) != null) //null is when the row only contains empty cells 
            {
                ConcessionDto concession = new()
                {
                    ConcessionId = sheet.GetRow(row).GetCell(0).StringCellValue,
                    ConcessionName = sheet.GetRow(row).GetCell(1).StringCellValue,
                };
                concessions.Add(concession);
            }
        }

        await concessionsRepository.CreateNewConcessionsAsync(concessions);
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