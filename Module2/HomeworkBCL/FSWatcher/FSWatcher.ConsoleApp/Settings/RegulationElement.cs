using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Text.RegularExpressions;

namespace FSWatcher.ConsoleApp.Settings
{
    public class RegulationElement : ConfigurationElement
    {
        [ConfigurationProperty("template", IsKey = true)]
        public string Template => (string) base["template"];

        [ConfigurationProperty("destinationFolder")]
        public string DestinationFolder => (string)base["destinationFolder"];

        [ConfigurationProperty("onSerialNumber")]
        public bool OnSerialNumber => (bool)base["onSerialNumber"];

        [ConfigurationProperty("onMoveDate")]
        public bool OnMoveDate => (bool)base["onMoveDate"];
    }
}
