using System;
using System.Linq;
using IntroductionToNet.Shared.Library;

namespace IntroductionToNet.Projects.ConsoleApp
{
    class Program
    {
        static void Main(string[] args) 
            => Console.WriteLine(MessageGenerator.GetGreeting(args.FirstOrDefault()));
    }
}
