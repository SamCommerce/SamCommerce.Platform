using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamCommerce.Platform.Caching
{
    public class CachingOptions
    {
        public bool CacheEnabled { get; set; } = true;

        public TimeSpan? CacheAbsoluteExpiration { get; set; }
        public TimeSpan? CacheSlidingExpiration { get; set; } = TimeSpan.FromMinutes(5);
    }
}

