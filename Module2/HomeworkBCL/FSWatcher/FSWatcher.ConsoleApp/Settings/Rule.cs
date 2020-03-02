using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FSWatcher.ConsoleApp.Settings
{
    public class Rule
    {
        public string Pattern { get; set; }
        public string DestinationFolder { get; set; }
    }
}