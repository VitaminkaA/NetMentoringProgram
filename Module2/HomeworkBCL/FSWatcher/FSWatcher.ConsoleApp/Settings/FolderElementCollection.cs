using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace FSWatcher.ConsoleApp.Settings
{
    public class FolderElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement() 
            => new FolderElement();

        protected override object GetElementKey(ConfigurationElement element) 
            => ((FolderElement) element).Path;
    }
}
