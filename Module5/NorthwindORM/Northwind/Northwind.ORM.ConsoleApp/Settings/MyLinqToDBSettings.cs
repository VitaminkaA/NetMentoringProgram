using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LinqToDB.Configuration;
using Microsoft.Extensions.Options;

namespace Northwind.ORM.ConsoleApp.Settings
{
    public class MyLinqToDBSettings : ILinqToDBSettings
    {
        public IConnectionStringSettings _connectionStringSettings;

        public MyLinqToDBSettings(IConnectionStringSettings connectionStringSettings) =>
            _connectionStringSettings = connectionStringSettings 
                                        ?? throw new ArgumentNullException();

        public IEnumerable<IDataProviderSettings> DataProviders => 
            Enumerable.Empty<IDataProviderSettings>();

        public string DefaultConfiguration => "SqlServer";
        public string DefaultDataProvider => "SqlServer";

        public IEnumerable<IConnectionStringSettings> ConnectionStrings
        {
            get { yield return _connectionStringSettings; }
        }
    }
}
