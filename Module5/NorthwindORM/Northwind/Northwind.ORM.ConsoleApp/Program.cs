using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Northwind.ORM.ConsoleApp.Extensions;

namespace Northwind.ORM.ConsoleApp
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            await CreateServiceProvider()
                .GetService<App>()
                .Run();
        }

        private static IServiceProvider CreateServiceProvider()
        {
            return new ServiceCollection()
                .RegisterDependencies()
                .BuildServiceProvider();
        }
    }
}
