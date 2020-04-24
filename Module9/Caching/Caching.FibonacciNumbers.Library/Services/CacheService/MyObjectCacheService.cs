using System;
using System.Runtime.Caching;
using Caching.FibonacciNumbers.Library.Settings;
using Microsoft.Extensions.Options;

namespace Caching.FibonacciNumbers.Core.Services.CacheService
{
    public class MyObjectCacheService : ICacheService
    {
        private const int DEFAULT_SLIDING_EXPIRATION = 30;

        private readonly ObjectCache _cache;
        private readonly CacheItemPolicy _cacheItemPolicy;

        public MyObjectCacheService(IOptions<CacheItemSettings> options)
        {
            _cache = MemoryCache.Default;
            var opt = options?.Value;
            _cacheItemPolicy = new CacheItemPolicy
            {
                SlidingExpiration = TimeSpan.FromSeconds(opt?.SlidingExpiration 
                                                         ?? DEFAULT_SLIDING_EXPIRATION),
            };
        }

        public T TryGet<T>(string key) where T : class
        {
            if(string.IsNullOrWhiteSpace(key))
                throw new ArgumentException(nameof(key));

            return (T)_cache.Get(key);
        }
        public void Set<T>(string key, T value) where T : class
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException(nameof(key));
            if (value==null)
                throw new ArgumentNullException(nameof(value));

            _cache.Set(key, value, _cacheItemPolicy);
        }
    }
}
