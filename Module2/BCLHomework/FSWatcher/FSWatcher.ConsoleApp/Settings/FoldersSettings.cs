using System;
using System.Collections.Generic;
using System.Text;

namespace FSWatcher.ConsoleApp.Settings
{
    public class FoldersSettings
    {
        public string Path { get; set; }
        public string DefaultMoveFolder { get; set; }
        public bool IncludeNumbering { get; set; }
        public IEnumerable<Rule> Rules { get; set; }
        public bool IncludeMoveDate { get; set; }
    }
}
