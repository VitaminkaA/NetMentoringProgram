using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Northwind.EF.DAL.Context;
using Northwind.EF.DAL.Repositories;

namespace Northwind.ConsoleApp.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection RegisterDependencies(this IServiceCollection services)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            services.AddDbContext<NorthwindEFContext>(opt =>
            {
                opt.UseSqlServer(builder.GetConnectionString("NorthwindEF"),
                    sqlOpt => sqlOpt.MigrationsAssembly("Northwind.Migrations"));
                opt.UseLazyLoadingProxies();
            },
                ServiceLifetime.Singleton);

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddSingleton<Application>();

            return services;
        }
    }
}
