namespace Caching.FibonacciNumbers.Core.Services.CacheService
{
    public interface ICacheService
    {
        public T TryGet<T>(string key) where T : class;
        public void Set<T>(string key, T value) where T : class;
    }
}
