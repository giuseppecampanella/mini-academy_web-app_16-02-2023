using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;

class Program
{
    static async Task Main(string[] args)
    {
        //var collection = new ServiceCollection();

        //collection
        //    .AddLogging()
        //    .AddDbContext<SchoolContext>(options =>
        //        options.UseSqlServer("Server=(localdb)\\\\MSSQLLocalDB;Database=NetAcademy;Trusted_Connection=True;"))
        //        .AddScoped<IStudentsRepository, StudentsRepository>()
        //        .AddScoped<ICoursesRepository, CoursesRepository>()
        //        .AddScoped<ITeachersRepository, TeachersRepository>()
        //        .AddScoped<StudentsService>()
        //        .AddScoped<CoursesService>()
        //        .AddScoped<TeachersService>();

        //var service = collection.BuildServiceProvider();
        //var _service = service.GetService<StudentsService>();

        //var res = await _service.GetStudentCoursesAndTeachersAsync(2);

        //string json = JsonSerializer.Serialize(res, new JsonSerializerOptions() { WriteIndented = true });
        //Console.WriteLine(json);

    }
}