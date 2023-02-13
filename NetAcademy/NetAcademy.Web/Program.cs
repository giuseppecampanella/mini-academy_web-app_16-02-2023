using Microsoft.EntityFrameworkCore;
using NetAcademy.Domain;
using NetAcademy.Domain.Models.Configuration;
using NetAcademy.Repositories;
using NetAcademy.Repository.Implementations;
using NetAcademy.Repository.Interfaces;
using NetAcademy.Services;
using NLog;
using NLog.Web;
using StackExchange.Redis;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddControllers();

    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    builder.Services.Configure<NodeRedConfig>(builder.Configuration.GetSection(Constants.NodeRedSectionKeyName));

    //Inserimento del HttpClientFactory nel DI per le chiamate REST in background
    builder.Services.AddHttpClient(Constants.HttpClientName,
        c => { c.Timeout = TimeSpan.FromSeconds(builder.Configuration.GetValue<int>(Constants.HttpClientTimeoutKey)); });

    builder.Services.AddDbContext<XwareContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString(Constants.DB_CONNECTION_KEY)));

    builder.Services.AddSingleton<IConnectionMultiplexer>(provider =>
    {
        return ConnectionMultiplexer.Connect(builder.Configuration.GetValue<string>(Constants.RedisConnectionStringKeyName));
    });

    // NODE-RED
    //builder.Services.AddScoped<IConcessionsRepository>(provider =>
    //{
    //    ILogger<ConcessionsNodeRedRepository> logger = provider.GetRequiredService<ILogger<ConcessionsNodeRedRepository>>();
    //    IOptions<NodeRedConfig> nodeRedConfig = provider.GetRequiredService<IOptions<NodeRedConfig>>();
    //    IHttpClientFactory factory = provider.GetRequiredService<IHttpClientFactory>();
    //    return new ConcessionsNodeRedRepository(logger, nodeRedConfig, factory, new Uri(builder.Configuration.GetValue<string>(Constants.NodeRedUrlKeyName)));
    //});

    // REDIS + NODE-RED
    //builder.Services.AddScoped<IConcessionsRepository>(provider =>
    //{
    //    ILogger<ConcessionsRedisRepository> logger = provider.GetRequiredService<ILogger<ConcessionsRedisRepository>>();
    //    IOptions<NodeRedConfig> nodeRedConfig = provider.GetRequiredService<IOptions<NodeRedConfig>>();
    //    IHttpClientFactory factory = provider.GetRequiredService<IHttpClientFactory>();
    //    IConnectionMultiplexer connectionMultiplexer = provider.GetRequiredService<IConnectionMultiplexer>();
    //    return new ConcessionsRedisRepository
    //    (
    //        logger,
    //        nodeRedConfig,
    //        connectionMultiplexer,
    //        factory,
    //        new Uri(builder.Configuration.GetValue<string>(Constants.NodeRedUrlKeyName))
    //    );
    //});

    // SQL SERVER
    builder.Services.AddScoped<IConcessionsRepository, ConcessionsSqlDatabaseRepository>();
    builder.Services.AddScoped<ICountriesRepository, CountriesSqlDatabaseRepository>();

    builder.Services.AddTransient<ConcessionsService>();
    builder.Services.AddTransient<CountriesService>();
    builder.Services.AddTransient<ExcelService>();

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception exception)
{
    // NLog: catch setup errors
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    NLog.LogManager.Shutdown();
}