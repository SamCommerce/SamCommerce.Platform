using SamCommerce.Platform.Core.Common;
using SamCommerce.Platform.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamCommerce.Platform.Core.ChangeLog
{
    public class ChangeLogSearchCriteria : SearchCriteriaBase
    {
        public EntryState[] OperationTypes { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
