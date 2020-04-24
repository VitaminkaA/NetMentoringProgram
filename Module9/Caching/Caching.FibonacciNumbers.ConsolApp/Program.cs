using System;
using Caching.FibonacciNumbers.ConsolApp.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Caching.FibonacciNumbers.ConsolApp
{
    class Program
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
    }
}
