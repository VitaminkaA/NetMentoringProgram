using System;
using System.Collections.Generic;
using Caching.FibonacciNumbers.Core.Services.CacheService;

namespace Caching.FibonacciNumbers.Core.Services.FibonacciService
{
    public class FibonacciSequenceCacheDecorator : IFibonacciSequence
    {
        private readonly ICacheService _cache;
        private readonly FibonacciSequence _sequence;

        public FibonacciSequenceCacheDecorator(ICacheService cache)
        {
            _cache = cache;
            _sequence = new FibonacciSequence();
        }

        public IEnumerable<int> GetNumbers(int count)
        {
            if (count <= 0)
                throw new ArgumentException(nameof(count));

            var cacheKey = $"{count}";
            var res = _cache.TryGet<IEnumerable<int>>(cacheKey);

            if (res != null)
                return res;

            var sequence = _sequence.GetNumbers(count);
            _cache.Set(cacheKey, sequence);
            return sequence;
        }
    }
}
