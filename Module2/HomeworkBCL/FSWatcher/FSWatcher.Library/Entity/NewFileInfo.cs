using System;
using System.Collections.Generic;
using System.Text;

namespace FSWatcher.Library.Entity
{
    public class NewFileInfo
    {
        public string Path { get; set; }
        public string Name { get; set; }
        public DateTimeOffset DateTime { get; set; }
    }
}
