using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace FSWatcher.ConsoleApp.Extension
{
    public static class ConfigurationExtension
    {
        public static T Configure<T>(this IConfiguration configuration, string section)
            where T : class
        {
            if(section==null)
                throw new ArgumentNullException();

            return configuration.GetSection(section)
                .Get<T>();
        }
    }
}
