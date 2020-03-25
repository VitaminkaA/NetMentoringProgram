using System;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using Northwind.ConsoleApp.Extensions;
using Northwind.EF.DAL.Context;

namespace Northwind.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
             CreateServiceProvider()
                .GetService<Application>()
                .Run();
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
