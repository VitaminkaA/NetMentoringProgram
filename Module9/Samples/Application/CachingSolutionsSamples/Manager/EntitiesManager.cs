using NorthwindLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Caching;
using System.Threading;
using CachingSolutionsSamples.Service;

namespace CachingSolutionsSamples.Manager
{
    public class EntitiesManager
    {
        private readonly IMyCache _cache;

        public EntitiesManager(IMyCache cache) => _cache = cache;

        public IEnumerable<T> GetItems<T>() where T : BaseEntity
        {
            var entityName = typeof(T).Name;
            Console.WriteLine($"Get {entityName}");

            var key = $"{Constants.PREFIX}_{entityName}_{Thread.CurrentPrincipal.Identity.Name}";

            var items = _cache.TryGet<IEnumerable<T>>(key);
            if (items != null) return items;

            Console.WriteLine("From DB");
            using var dbContext = new Northwind();
            dbContext.Configuration.LazyLoadingEnabled = false;
            dbContext.Configuration.ProxyCreationEnabled = false;
            var dbSet = dbContext.Set<T>();
            items = dbSet.ToList();

            SqlDependency.Start(dbContext.Database.Connection.ConnectionString);
            var cachePolicy = new CachePolicy
            {
                ChangeMonitor = new SqlChangeMonitor(new SqlDependency(new SqlCommand(dbSet.Sql))),
            };
            _cache.Set(key, items, cachePolicy);
            SqlDependency.Stop(dbContext.Database.Connection.ConnectionString);

            return items;
        }
    }
}
