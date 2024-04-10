using SamCommerce.Platform.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamCommerce.Platform.Core.Security.Search
{
    public class UserSearchResult : GenericSearchResult<ApplicationUser>
    {
        public IList<ApplicationUser> Users => Results;
    }
}
