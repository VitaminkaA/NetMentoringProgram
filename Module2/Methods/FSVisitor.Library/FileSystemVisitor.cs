using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSVisitor.Library.Entity;

namespace FSVisitor.Library
{
    public class FileSystemVisitor
    {
        protected IFileSystemProvider FileSystemProvider = new FileSystemProvider();
        private readonly bool _isFilterOn;
        public Predicate<FileSystemEntry> Filter { get; }

        public event Action Start, Finish;

        public event Action<FileSystemEntry> FileFound, DirectoryFound, FilteredFileFound, FilteredDirectoryFound;

        public FileSystemVisitor() { }

        public FileSystemVisitor(Predicate<FileSystemEntry> filter) : this()
        {
            Filter = filter 
                     ?? throw new NullReferenceException();
            _isFilterOn = true;
        }

        public IEnumerable<FileSystemEntry> Visit(string path)
        {
            if (path == null)
                throw new NullReferenceException();

            CallEvent(Start);
            foreach (var entry in FileSystemProvider.EnumerateFileSystemEntries(path))
            {
                var isDirectory = entry.Type == FileSystemEntryType.Directory;
                CallEvent(isDirectory ? DirectoryFound : FileFound, entry);
                if (_isFilterOn)
                    if (FilterOut(entry))
                        CallEvent(isDirectory ? FilteredDirectoryFound : FilteredFileFound, entry);
                    else
                        entry.Skip = true;
                if (entry.Skip)
                    continue;
                if (entry.StopSearch)
                    break;
                yield return entry;
            }
            CallEvent(Finish);
        }

        private bool FilterOut(FileSystemEntry fileInfo)
            => Filter.Invoke(fileInfo);

        private static void CallEvent(Action action)
            => action?.Invoke();

        private static void CallEvent<T>(Action<T> action, T entry)
            => action?.Invoke(entry);
    }
}