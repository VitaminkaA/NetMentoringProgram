using System;
using Caching.FibonacciNumbers.Core.Services.FibonacciService;

namespace Caching.FibonacciNumbers.ConsolApp
{
    public class Application
    {
        private readonly IFibonacciSequence _sequence;

        public Application(IFibonacciSequence sequence)
        {
            _sequence = sequence;
        }

        public void Run()
        {
            var line = Console.ReadLine();
            int.TryParse(line, out var count);

            Console.WriteLine("Result:");
            foreach (var el in _sequence.GetNumbers(count))
                Console.WriteLine(el);
        }
    }
}
