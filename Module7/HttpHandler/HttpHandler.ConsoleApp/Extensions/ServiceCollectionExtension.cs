using HttpHandler.BL.Services;
using HttpHandler.DAL.Context;
using HttpHandler.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HttpHandler.ConsoleApp.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection RegisterDependencies(this IServiceCollection services)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            services.AddDbContext<NorthwindEFContext>(opt =>
                opt.UseSqlServer(builder.GetConnectionString("Northwind")),
            ServiceLifetime.Singleton);

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IOrderService, OrderService>();

            services.AddSingleton<Application>();

            return services;
        }
    }
}
