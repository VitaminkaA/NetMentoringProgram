using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FSWatcher.Library.Entity
{
    public class TrackedFolder
    {
        public string Path { get; set; }
        public string DefaultMoveFolder { get; set; }
        public bool IncludeNumbering { get; set; }
        public bool IncludeMoveDate { get; set; }
        public Dictionary<Regex, string> Templates { get; set; }
        public int Count { get; set; }
    }
}
