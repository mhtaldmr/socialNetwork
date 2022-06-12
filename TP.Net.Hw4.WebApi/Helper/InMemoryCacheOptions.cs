using Microsoft.Extensions.Caching.Memory;

namespace TP.Net.Hw4.WebApi.Helper
{
    public class InMemoryCacheOptions
    {
        public static MemoryCacheEntryOptions CacheOptions()
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
