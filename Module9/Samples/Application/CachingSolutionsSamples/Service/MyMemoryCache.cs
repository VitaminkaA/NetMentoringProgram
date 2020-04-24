using System;
using System.Runtime.Caching;

namespace CachingSolutionsSamples.Service
{
    public class MyMemoryCache : IMyCache
    {
        private readonly TimeSpan _defSlidingExpiration = TimeSpan.FromSeconds(Constants.DEFAULT_SLIDING_EXPIRATION);
        private readonly ObjectCache _cache;
        private readonly CacheItemPolicy _cacheItemPolicy;

        public MyMemoryCache()
        {
            _cache = MemoryCache.Default;
            _cacheItemPolicy = new CacheItemPolicy
            {
                SlidingExpiration = _defSlidingExpiration,
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

        public void Set<T>(string key, T value, CachePolicy policy) where T : class
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException(nameof(key));
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            if (policy == null)
                throw new ArgumentNullException(nameof(policy));

            var cachePolicy = new CacheItemPolicy
            {
                SlidingExpiration = policy?.SlidingExpiration 
                                    ?? _defSlidingExpiration
            };

            if(policy.ChangeMonitor!=null)
                cachePolicy.ChangeMonitors.Add(policy.ChangeMonitor);

            _cache.Set(key, value, cachePolicy);
        }
    }
}
