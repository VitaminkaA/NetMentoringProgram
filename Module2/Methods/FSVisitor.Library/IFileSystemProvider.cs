using System;
using System.Collections.Generic;
using System.Text;
using FSVisitor.Library.Entity;

namespace FSVisitor.Library
{
    public interface IFileSystemProvider
    {
        IEnumerable<FileSystemEntry> EnumerateFileSystemEntries(string path);
    }
}
