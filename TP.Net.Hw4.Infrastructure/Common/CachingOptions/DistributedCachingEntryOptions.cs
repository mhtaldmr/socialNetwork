using Microsoft.Extensions.Caching.Distributed;

namespace TP.Net.Hw4.Infrastructure.Caching
{
    public class DistributedCachingEntryOptions
    {
        public static DistributedCacheEntryOptions DistributedCachingEntryOptionsParams()
        {
            var cacheEntryOptions = new DistributedCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromSeconds(60))
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(3600));

                return cacheEntryOptions;
        }
    }
}
