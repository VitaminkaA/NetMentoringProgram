using NorthwindLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CachingSolutionsSamples.Service;

namespace CachingSolutionsSamples
{
    public class CategoriesManager
    {
        private readonly IMyCache _cache;
        private const string PREFIX = "Cache_Categories";

        public CategoriesManager(IMyCache cache)
        {
            _cache = cache;
        }

        public IEnumerable<Category> GetCategories()
        {
            Console.WriteLine("Get Categories");

            var key = PREFIX + Thread.CurrentPrincipal.Identity.Name;
            var categories = _cache.TryGet<IEnumerable<Category>>(key);
            if (categories != null) return categories;

            Console.WriteLine("From DB");
            using (var dbContext = new Northwind())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                dbContext.Configuration.ProxyCreationEnabled = false;
                categories = dbContext.Categories.ToList();
                _cache.Set(key, categories);
            }

            return categories;
        }
    }
}
