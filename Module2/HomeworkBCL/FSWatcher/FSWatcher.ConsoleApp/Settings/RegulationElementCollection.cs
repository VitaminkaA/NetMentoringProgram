using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace FSWatcher.ConsoleApp.Settings
{
    public class RegulationElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new RegulationElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((RegulationElement)element).Template;
        }
    }
}
