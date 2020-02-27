using FSVisitor.Library;
using System;
using System.IO;
using System.Linq;

namespace FSVisitor.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = SetupFileSystemVisitorWithFilter()
                .Visit(new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory));

            foreach (var name in tree)
                Console.WriteLine(name.FullName);
        }

        private static FileSystemVisitor SetupFileSystemVisitorWithFilter()
        {
            //--- Without Filter
            var visitor = new FileSystemVisitor();

            //--- With Filter
            //var visitor = new FileSystemVisitor(x=>x.Attributes== FileAttributes.Directory);

            //--- With Start and Finish events
            visitor.Start += () => Console.WriteLine("Start");
            visitor.Finish += () => Console.WriteLine("Finish");

            //---With FileFound event
            visitor.FileFound += file =>
            {
                if (file.FileSystemInfo.Extension == ".json")
                    file.Skip = true;
                else
                    Console.Write("event FileFound:",ConsoleColor.DarkBlue);
            };

            //---With DirectoryFound event
            visitor.DirectoryFound += dir =>
            {
                Console.Write("event DirectoryFound:");
            };

            ////---With FilteredFileFound event(filter must be on)
            //visitor.FilteredFileFound += file =>
            //{
            //    Console.Write("event FilteredFileFound:");
            //};

            ////---With FilteredDirectoryFound event(filter must be on)
            //visitor.FilteredDirectoryFound += dir =>
            //{
            //    Console.Write("event FilteredDirectoryFound:");
            //};

            return visitor;
        }
    }
}
