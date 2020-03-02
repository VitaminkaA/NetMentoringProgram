using System;
using System.Collections.Generic;
using System.Text;

namespace FSVisitor.Library.Entity
{
    public class FileSystemEntry
    {
        public string FullName { get; set; }
        public DateTime CreationTime { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public FileSystemEntryType Type { get; set; }
        public bool StopSearch { get; set; }
        public bool Skip { get; set; }
    }
}
