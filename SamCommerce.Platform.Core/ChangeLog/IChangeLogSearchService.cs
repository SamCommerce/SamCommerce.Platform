using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamCommerce.Platform.Core.ChangeLog
{
    public interface IChangeLogSearchService
    {
        Task<ChangeLogSearchResult> SearchAsync(ChangeLogSearchCriteria criteria);
    }
}
