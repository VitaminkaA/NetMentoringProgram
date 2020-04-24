using System;
using System.Runtime.Caching;

namespace CachingSolutionsSamples.Service
{
    public class CachePolicy
    {
        public TimeSpan? SlidingExpiration { get; set; }
        public SqlChangeMonitor ChangeMonitor { get; set; }
    }
}
