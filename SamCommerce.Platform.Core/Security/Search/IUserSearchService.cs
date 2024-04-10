using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamCommerce.Platform.Core.Security.Search
{
    public interface IUserSearchService
    {
        Task<UserSearchResult> SearchUsersAsync(UserSearchCriteria criteria);

    }
}
