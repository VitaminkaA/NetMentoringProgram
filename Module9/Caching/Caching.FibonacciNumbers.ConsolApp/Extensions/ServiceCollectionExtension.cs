using Caching.FibonacciNumbers.Core.Services.CacheService;
using Caching.FibonacciNumbers.Core.Services.FibonacciService;
using Caching.FibonacciNumbers.Library.Settings;
using Microsoft.Extensions.Caching.Redis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Caching.FibonacciNumbers.ConsolApp.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection RegisterDependencies(this IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            services.Configure<CacheItemSettings>(configuration.GetSection("CacheItemSettings"));
            //services.AddSingleton<ICache, MyObjectCache>();
            //or
            services.Configure<RedisCacheOptions>(configuration.GetSection("RedisCacheSettings"));
            services.AddSingleton<ICacheService, MyRedisCacheService>();
            services.AddSingleton<IFibonacciSequence, FibonacciSequenceCacheDecorator>();
            services.AddSingleton<Application>();

            return services;
        }
    }
}
