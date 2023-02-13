using NetAcademy.Repository.Interfaces;

namespace NetAcademy.Services;

public class ExcelService
{
    private readonly IConcessionsRepository concessionsRepository;
    private readonly ICountriesRepository countriesRepository;

    public ExcelService(IConcessionsRepository concessionsRepository, ICountriesRepository countriesRepository)
    {
        this.concessionsRepository = concessionsRepository;
        this.countriesRepository = countriesRepository;
    }

    // Exercise
    public async Task LoadAllConcessionsAsync()
    {
        // TODO: leggere le concessions da file excel e salvare tutto su db
    }

    // Exercise
    public async Task LoadAllCountriesAsync()
    {
        // TODO: leggere le country da file excel e salvare tutto su db
    }

    // Exercise
    public async Task SaveConcessionsToExcelAsync(Stream writingStream)
    {
        // TODO: leggere le concessioni da db e salvare tutto su un file excel
    }

    // Exercise
    public async Task SaveConcessionsAndCountriesToExcel(Stream writingStream)
    {
        // TODO salvare concessions e countries che si trovano dentro la tabella CountryConcession
    }

}