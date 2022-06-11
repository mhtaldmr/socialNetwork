using Microsoft.Extensions.Caching.Memory;

namespace TP.Net.Hw4.Infrastructure.Caching
{
    public class InMemoryCacheEntryOptions
    {
        public static MemoryCacheEntryOptions InMemoryCacheEntryOptionParams()
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                   .SetSlidingExpiration(TimeSpan.FromSeconds(60))
                   .SetAbsoluteExpiration(TimeSpan.FromSeconds(3600))
                   .SetPriority(CacheItemPriority.Normal)
                   .SetSize(1024);

            return cacheEntryOptions;
        }
    }
}
