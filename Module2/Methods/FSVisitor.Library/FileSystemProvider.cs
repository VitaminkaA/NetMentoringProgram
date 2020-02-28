using FSVisitor.Library.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FSVisitor.Library
{
    public class FileSystemProvider : IFileSystemProvider
    {
        private readonly string _searchPattern = "*";
        public IEnumerable<FileSystemEntry> EnumerateFileSystemEntries(string path)
        {
            var dir = new DirectoryInfo(path
                                        ?? throw new NullReferenceException());

            if (!dir.Exists)
                throw new DirectoryNotFoundException();

            var options = new EnumerationOptions
            {
                RecurseSubdirectories = true,
                IgnoreInaccessible = true,
            };

            foreach (var entry in dir.EnumerateFileSystemInfos(_searchPattern, options))
                yield return new FileSystemEntry
                {
                    FullName = entry.FullName,
                    Name = entry.Name,
                    CreationTime = entry.CreationTime,
                    Extension = entry.Extension,
                    Type = entry is DirectoryInfo
                        ? FileSystemEntryType.Directory
                        : FileSystemEntryType.File
                };
        }
    }
}
