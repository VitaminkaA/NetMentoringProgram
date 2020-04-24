using System;
using Caching.FibonacciNumbers.Library.Settings;
using Microsoft.Extensions.Caching.Redis;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Caching.FibonacciNumbers.Core.Services.CacheService
{
    public class MyRedisCacheService : ICacheService, IDisposable
    {
        private const int DEFAULT_SLIDING_EXPIRATION = 5;

        private readonly RedisCache _cache;
        private readonly DistributedCacheEntryOptions _cacheEntryOptions;

        public MyRedisCacheService(IOptions<RedisCacheOptions> options, IOptions<CacheItemSettings> itemOpt)
        {
            _cache = new RedisCache(options);
            var itemOptVal = itemOpt?.Value;
            _cacheEntryOptions = new DistributedCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromSeconds(itemOptVal?.SlidingExpiration 
                                                         ?? DEFAULT_SLIDING_EXPIRATION)
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

        public void Dispose() => _cache.Dispose();
    }
}
