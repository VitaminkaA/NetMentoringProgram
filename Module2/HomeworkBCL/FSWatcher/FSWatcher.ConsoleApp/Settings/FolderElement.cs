using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace FSWatcher.ConsoleApp.Settings
{
    public class FolderElement : ConfigurationElement
    {
        [ConfigurationProperty("path", IsKey = true)]
        public string Path => (string)base["path"];
    }
}
