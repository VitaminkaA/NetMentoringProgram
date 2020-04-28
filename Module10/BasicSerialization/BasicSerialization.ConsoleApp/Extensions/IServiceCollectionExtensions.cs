using BasicSerialization.ConsoleApp.Settings;
using BasicSerialization.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BasicSerialization.ConsoleApp.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection RegisterDependencies(this IServiceCollection service)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            return service.AddSingleton<Application>()
                .AddSingleton<ISerializationService, SerializationService>()
                .AddSingleton<IBookSerializationToFileService,BookSerializationToFileService>()
                .Configure<BooksSettings>(config.GetSection("BooksSettings"));
        }
    }
}
