using System;
using System.Linq;

namespace ExceptionHandling.CharHandlerConsoleApp
{
    class Program
    {
        private static volatile bool isRunning = true;

        static void Main(string[] args)
        {
            Console.CancelKeyPress += Cansel;

            while (isRunning)
            {
                var line = Console.ReadLine();
                try
                {
                    Console.WriteLine($"First character: '{line.First()}'");
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine($"Exception: {e.Message}");
                }
            }
        }

        private static void Cansel(object sender, ConsoleCancelEventArgs e)
        {
            e.Cancel = true;
            isRunning = false;
        }
    }
}
