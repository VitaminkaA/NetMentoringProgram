using FSVisitor.Library;
using FSVisitor.Library.Entity;
using System;
using System.IO;
using System.Linq;

namespace FSVisitor.ConsoleApp
{
    //new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory)

    class Program
    {
        static void Main(string[] args)
        { 
            Console.WriteLine("Enter path:");
            var path = Console.ReadLine();

            var fsv = SetupFileSystemVisitorWithFilter();
            foreach (var entry in fsv.Visit(path))
                Console.WriteLine(entry.Name + entry.Extension);
        }

        private static FileSystemVisitor SetupFileSystemVisitorWithFilter()
        {
            //var visitor = new FileSystemVisitor();

            var visitor = new FileSystemVisitor(x => x.Type == FileSystemEntryType.Directory);

            visitor.Start += () => Console.WriteLine("Start");
            visitor.Finish += () => Console.WriteLine("Finish");

            visitor.FileFound += file =>
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                if (file.Extension == ".key")
                    file.Skip = true;
                else
                    Console.WriteLine("event FileFound:");
            };

            visitor.DirectoryFound += dir =>
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("event DirectoryFound:");
            };

            visitor.FilteredFileFound += file =>
            {
                Console.Write("event FilteredFileFound:");
            };

            visitor.FilteredDirectoryFound += dir =>
            {
                Console.Write("event FilteredDirectoryFound:");
            };

            return visitor;
        }
    }
}
