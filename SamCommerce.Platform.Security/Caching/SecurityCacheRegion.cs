using Microsoft.Extensions.Primitives;
using SamCommerce.Platform.Core.Caching;
using SamCommerce.Platform.Core.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamCommerce.Platform.Security.Caching
{
    public class SecurityCacheRegion : CancellableCacheRegion<SecurityCacheRegion>
    {
        public static IChangeToken CreateChangeTokenForUser(ApplicationUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            return CreateChangeTokenForKey(user.Id);
        }

        public static void ExpireUser(ApplicationUser user)
        {
            if (user != null)
            {
                ExpireTokenForKey(user.Id);
            }
        }
    }
}