using SamCommerce.Platform.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamCommerce.Platform.Core.Security.Search
{
    public class UserSearchCriteria : SearchCriteriaBase
    {
        public string MemberId { get; set; }
        public IList<string> MemberIds { get; set; }
        public DateTime? ModifiedSinceDate { get; set; }
        //Search users by their role names
        public string[] Roles { get; set; }
        public DateTime? LasLoginDate { get; set; }
        public bool OnlyUnlocked { get; set; }
        //TODO: Update UI pagination to use Skip and Take properties
    }
}
