using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace CachingSolutionsSamples.Service
{
    public class MyMemoryCache : IMyCache
    {
        private readonly ObjectCache _cache;
        private readonly CacheItemPolicy _cacheItemPolicy;

        public MyMemoryCache()
        {
            _cache = MemoryCache.Default;
            _cacheItemPolicy = new CacheItemPolicy
            {
                SlidingExpiration = TimeSpan.FromSeconds(Constants.DEFAULT_SLIDING_EXPIRATION)
            };
        }

        public T TryGet<T>(string key) where T : class
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException(nameof(key));

            return (T)_cache.Get(key);
        }
        public void Set<T>(string key, T value) where T : class
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException(nameof(key));
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            _cache.Set(key, value, _cacheItemPolicy);
        }
    }
}
