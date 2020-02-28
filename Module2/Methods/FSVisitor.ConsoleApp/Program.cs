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
            //--- Without Filter
            //var visitor = new FileSystemVisitor();

            //--- With Filter
            var visitor = new FileSystemVisitor(x => x.Type == FileSystemEntryType.Directory);

            //--- With Start and Finish events
            visitor.Start += () => Console.WriteLine("Start");
            visitor.Finish += () => Console.WriteLine("Finish");

            //---With FileFound event
            visitor.FileFound += file =>
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                if (file.Extension == ".key")
                    file.Skip = true;
                else
                    Console.WriteLine("event FileFound:");
            };

            //---With DirectoryFound event
            visitor.DirectoryFound += dir =>
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("event DirectoryFound:");
            };

            //---With FilteredFileFound event(filter must be on)
            visitor.FilteredFileFound += file =>
            {
                Console.Write("event FilteredFileFound:");
            };

            //---With FilteredDirectoryFound event(filter must be on)
            visitor.FilteredDirectoryFound += dir =>
            {
                Console.Write("event FilteredDirectoryFound:");
            };

            return visitor;
        }
    }
}
