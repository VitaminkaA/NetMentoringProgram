using System.Collections.Generic;
using System.Linq;
using LinqToDB.Configuration;
using LinqToDB.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Northwind.ORM.ConsoleApp.Settings;
using Northwind.ORM.DAL.Context;
using Northwind.ORM.DAL.Repositories;

namespace Northwind.ORM.ConsoleApp.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection RegisterDependencies(this IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            ;
            DataConnection.DefaultSettings 
                = new MyLinqToDBSettings(configuration.GetSection("Connection").Get<ConnectionStringSettings>());
            LinqToDB.Common.Configuration.Linq.AllowMultipleQuery = true;
            services.AddSingleton<ILinqToDBSettings, MyLinqToDBSettings>();
            services.AddSingleton<NorthwindLinq2dbContext>();
            services.AddScoped<IRepository, Repository>();
            
            services.AddSingleton<App>();

            return services;
        }
    }
}