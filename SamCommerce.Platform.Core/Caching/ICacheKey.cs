﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamCommerce.Platform.Core.Caching
{
    public interface ICacheKey
    {
        string GetCacheKey();
    }
}
