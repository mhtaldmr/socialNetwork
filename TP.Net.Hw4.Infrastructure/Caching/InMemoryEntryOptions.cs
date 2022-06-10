using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.Net.Hw4.Infrastructure.Caching
{
    public class InMemoryEntryOptions
    {
        public static MemoryCacheEntryOptions InMemoryEntryOptionParams()
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
