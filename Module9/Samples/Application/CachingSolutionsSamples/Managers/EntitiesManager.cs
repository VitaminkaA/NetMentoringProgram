using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using CachingSolutionsSamples.Service;
using NorthwindLibrary;

namespace CachingSolutionsSamples.Managers
{
    public class EntitiesManager
    {
        private readonly IMyCache _cache;
        private const string PREFIX = "Cache";

        public EntitiesManager(IMyCache cache) =>
            _cache = cache;

        public IEnumerable<T> GetItems<T>() where T : BaseEntity
        {
            var entityName = typeof(T).Name;
            Console.WriteLine($"Get {entityName}");

            var key = $"{PREFIX}_{entityName}_{Thread.CurrentPrincipal.Identity.Name}";

            var items = _cache.TryGet<IEnumerable<T>>(key);
            if (items != null) return items;

            Console.WriteLine("From DB");
            using var dbContext = new Northwind();
            dbContext.Configuration.LazyLoadingEnabled = false;
            dbContext.Configuration.ProxyCreationEnabled = false;
            items = dbContext.Set<T>().ToList();
            _cache.Set(key, items);

            return items;
        }
    }
}
