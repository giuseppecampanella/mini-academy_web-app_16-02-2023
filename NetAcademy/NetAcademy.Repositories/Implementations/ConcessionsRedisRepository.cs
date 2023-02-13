using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NetAcademy.Domain.Models.Configuration;
using NetAcademy.Domain.Models.DTOs;
using StackExchange.Redis;
using System.Text.Json;

namespace NetAcademy.Repository.Implementations;

public class ConcessionsRedisRepository : ConcessionsNodeRedRepository
{
    private ILogger<ConcessionsRedisRepository> logger;
    private readonly IConnectionMultiplexer connectionMultiplexer;

    public ConcessionsRedisRepository(ILogger<ConcessionsRedisRepository> l,
        IOptions<NodeRedConfig> nodeRedConfig,
        IConnectionMultiplexer connectionMultiplexer,
        IHttpClientFactory httpClientFactory,
        Uri host) : base(l, nodeRedConfig, httpClientFactory, host)
    {
        logger = l;
        this.connectionMultiplexer = connectionMultiplexer;
    }

    private string Serialize<T>(T obj)
    {
        return JsonSerializer.Serialize<T>(obj);
    }

    private T Deserialize<T>(string serializedObj)
    {
        return JsonSerializer.Deserialize<T>(serializedObj);
    }

    public override async Task<List<ConcessionDto>> GetAllConcessionsAsync()
    {
        IDatabase db = connectionMultiplexer.GetDatabase();
        RedisValue resRedis = await db.StringGetAsync("Concessions");
        if (resRedis.IsNullOrEmpty)
        {
            List<ConcessionDto> concessions = await base.GetAllConcessionsAsync();

            db.StringSet("Concessions", Serialize<List<ConcessionDto>>(concessions));
            db.KeyExpire("Concessions", TimeSpan.FromHours(1));
            return concessions;
        }
        return Deserialize<List<ConcessionDto>>(resRedis);
    }

    public Task CreateNewConcessionAsync(ConcessionDto concession)
    {
        throw new NotImplementedException();
    }

    public Task DeleteConcessionAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<ConcessionDto?> GetConcessionAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateConcessionAsync(string id, ConcessionDto dto)
    {
        throw new NotImplementedException();
    }
}