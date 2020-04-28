using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using BasicSerialization.ConsoleApp.Extensions;

namespace BasicSerialization.ConsoleApp
{
    class Program
    {
        static void Main(string[] args) => 
             CreateServiceProvider()
                .GetService<Application>()
                .Run();

        private static IServiceProvider CreateServiceProvider() =>
            new ServiceCollection()
                .RegisterDependencies()
                .BuildServiceProvider();
    }
}
