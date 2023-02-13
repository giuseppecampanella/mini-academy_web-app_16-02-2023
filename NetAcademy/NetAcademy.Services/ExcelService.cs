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
    private readonly IExtCountriesConcessionsRepository extCountriesConcessionsRepository;

    public ExcelService(IConcessionsRepository concessionsRepository, IExtCountriesRepository extCountriesRepository, IExtCountriesConcessionsRepository extCountriesConcessionsRepository)
    {
        this.concessionsRepository = concessionsRepository;
        this.extCountriesRepository = extCountriesRepository;
        this.extCountriesConcessionsRepository = extCountriesConcessionsRepository;
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
        List<ExtCountryDto> extCountries = new();

        XSSFWorkbook xssfwb;
        using (FileStream file = new("Files/data.xlsx", FileMode.Open, FileAccess.Read))
        {
            xssfwb = new XSSFWorkbook(file);
        }

        ISheet sheet = xssfwb.GetSheet("ExtCountriesV2");
        for (int row = 1; row <= sheet.LastRowNum; row++)
        {
            if (sheet.GetRow(row) != null) //null is when the row only contains empty cells 
            {
                ExtCountryDto extCountry = new()
                {
                    CountryId = sheet.GetRow(row).GetCell(0).StringCellValue,
                    CountryName = sheet.GetRow(row).GetCell(1).StringCellValue,
                    //CountryCode = sheet.GetRow(row).GetCell(2).StringCellValue,

                };
                extCountries.Add(extCountry);
            }
        }

        await extCountriesRepository.CreateNewExtCountriesAsync(extCountries);
    }

    // Exercise
    public async Task SaveConcessionsToExcelAsync(Stream writingStream)
    {
        // TODO: leggere le concessioni da db e salvare tutto su un file excel
        List<ConcessionDto> concessions = await concessionsRepository.GetAllConcessionsAsync();

        var wb = new XSSFWorkbook();

        ISheet sheet = wb.CreateSheet("Concessions");
        IRow HeaderRow = sheet.CreateRow(0);

        HeaderRow.CreateCell(0).SetCellValue("ConcessionId");
        HeaderRow.CreateCell(1).SetCellValue("ConcessionName");

        int rowIndex = 1;
        foreach(ConcessionDto concession in concessions)
        {
            IRow row = sheet.CreateRow(rowIndex);
            row.CreateCell(0).SetCellValue(concession.ConcessionId);
            row.CreateCell(1).SetCellValue(concession.ConcessionName);
            rowIndex++;
        }

        wb.Write(writingStream);

    }

    // Exercise
    public async Task SaveConcessionsAndExtCountriesToExcel(Stream writingStream)
    {
        // TODO salvare concessions e countries che si trovano dentro la tabella ExtCountryConcession
        List<ExtCountryConcessionInfoDto> values = await extCountriesConcessionsRepository.GetAllAsync();

        var wb = new XSSFWorkbook();

        ISheet sheet = wb.CreateSheet("ConcessionsExtCountries");
        IRow HeaderRow = sheet.CreateRow(0);

        HeaderRow.CreateCell(0).SetCellValue("ConcessionId");
        HeaderRow.CreateCell(1).SetCellValue("ConcessionName");
        HeaderRow.CreateCell(2).SetCellValue("CountryId");
        HeaderRow.CreateCell(3).SetCellValue("CountryName");

        int rowIndex = 1;
        foreach (ExtCountryConcessionInfoDto val in values)
        {
            IRow row = sheet.CreateRow(rowIndex);
            row.CreateCell(0).SetCellValue(val.ConcessionId);
            row.CreateCell(1).SetCellValue(val.ConcessionName);
            row.CreateCell(2).SetCellValue(val.CountryId);
            row.CreateCell(3).SetCellValue(val.CountryName);
            rowIndex++;
        }

        wb.Write(writingStream);

    }

}