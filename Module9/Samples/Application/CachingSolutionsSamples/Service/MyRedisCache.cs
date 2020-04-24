using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Redis;
using Newtonsoft.Json;
using System;

namespace CachingSolutionsSamples.Service
{
    public class MyRedisCache : IMyCache
    {
        private readonly TimeSpan _defSlidingExpiration = TimeSpan.FromSeconds(Constants.DEFAULT_SLIDING_EXPIRATION);
        
        private readonly RedisCache _cache;
        private readonly DistributedCacheEntryOptions _cacheEntryOptions;

        public MyRedisCache(RedisCacheOptions options)
        {
            _cache = new RedisCache(options);
            _cacheEntryOptions = new DistributedCacheEntryOptions
            {
                SlidingExpiration = _defSlidingExpiration
            };
        }

        public T TryGet<T>(string key) where T : class
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException(nameof(key));

            var jsonString = _cache.GetString(key);
            return jsonString == null ? null
                : JsonConvert.DeserializeObject<T>(jsonString);
        }
        public void Set<T>(string key, T value) where T : class
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException(nameof(key));
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            var jsonString = JsonConvert.SerializeObject(value);
            _cache.SetString(key, jsonString, _cacheEntryOptions);
        }

        public void Set<T>(string key, T value, CachePolicy policy) where T : class
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException(nameof(key));
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            if (policy == null)
                throw new ArgumentNullException(nameof(policy));

            var cacheEntryOptions = new DistributedCacheEntryOptions
            {
                SlidingExpiration = policy?.SlidingExpiration ?? _defSlidingExpiration
            };

            var jsonString = JsonConvert.SerializeObject(value);
            _cache.SetString(key, jsonString, _cacheEntryOptions);
        }

        public void Dispose() => _cache.Dispose();
    }
}
