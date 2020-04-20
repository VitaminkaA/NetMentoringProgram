using LogQuery = Interop.MSUtil.LogQueryClassClass;
using System;

namespace LogParser.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1 || string.IsNullOrWhiteSpace(args[0]))
                throw new ArgumentNullException();

            var query = args[0];
            try
            {
                new LogQuery().ExecuteBatch(query);
                Console.WriteLine("Done!");
                Console.ReadLine();
            }
            catch (System.Runtime.InteropServices.COMException exc)
            {
                Console.WriteLine("Unexpected error: " + exc.Message);
            }
        }

    }
}
