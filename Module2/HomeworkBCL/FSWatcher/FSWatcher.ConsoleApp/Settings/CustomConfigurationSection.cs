using System.Configuration;

namespace FSWatcher.ConsoleApp.Settings
{
    public class CustomConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("culture", DefaultValue = "ru-Ru")]
        public string Culture => (string)base["culture"];

        [ConfigurationProperty("watchedFolders")]
        public FolderElementCollection Folders => (FolderElementCollection)base["watchedFolders"];

        [ConfigurationProperty("regulations")]
        public RegulationElementCollection Regulations => (RegulationElementCollection)this["regulations"];
    }
}
