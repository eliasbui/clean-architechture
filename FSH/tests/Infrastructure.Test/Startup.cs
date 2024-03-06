using FSH.Application.Common.Interfaces;
using FSH.Application.Common.Persistence;
using FSH.Infrastructure.Caching;
using FSH.Infrastructure.Common.Services;
using FSH.Infrastructure.Localization;
using FSH.Infrastructure.Persistence.ConnectionString;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Infrastructure.Test;

public class Startup
{
    public static void ConfigureHost(IHostBuilder host)
    {
        host.ConfigureHostConfiguration(config => config.AddJsonFile("appsettings.json"));
    }

    public static void ConfigureServices(IServiceCollection services, HostBuilderContext context)
    {
        services
            .AddTransient<IMemoryCache, MemoryCache>()
            .AddTransient<LocalCacheService>()
            .AddTransient<IDistributedCache, MemoryDistributedCache>()
            .AddTransient<ISerializerService, NewtonSoftService>()
            .AddTransient<DistributedCacheService>()
            .AddPOLocalization(context.Configuration)
            .AddTransient<IConnectionStringSecurer, ConnectionStringSecurer>();
    }
}