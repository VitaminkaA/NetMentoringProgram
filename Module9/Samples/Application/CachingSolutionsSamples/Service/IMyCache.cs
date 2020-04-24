using System.Collections.Generic;

namespace CachingSolutionsSamples.Service
{
    public interface IMyCache
    {
        T TryGet<T>(string key) where T : class;
        void Set<T>(string key, T value) where T : class;
        void Set<T>(string key, T value, CachePolicy policy) where T : class;
    }
}
