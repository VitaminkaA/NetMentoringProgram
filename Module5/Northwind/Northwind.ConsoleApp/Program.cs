using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using Northwind.ConsoleApp.Extensions;
using Northwind.EF.DAL.Context;

namespace Northwind.ConsoleApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await CreateServiceProvider()
                .GetService<Application>()
                .RunAsync();
        }

        private static IServiceProvider CreateServiceProvider()
        {
            return new ServiceCollection()
                .RegisterDependencies()
                .BuildServiceProvider();
        }

        private class Factory : IDesignTimeDbContextFactory<NorthwindEFContext>
        {
            public NorthwindEFContext CreateDbContext(string[] args)
                => CreateServiceProvider().GetService<NorthwindEFContext>();
        }
    }
}
