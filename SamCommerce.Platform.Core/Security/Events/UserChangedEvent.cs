using SamCommerce.Platform.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamCommerce.Platform.Core.Security.Events
{
    public class UserChangedEvent : GenericChangedEntryEvent<ApplicationUser>
    {
        public UserChangedEvent(IEnumerable<GenericChangedEntry<ApplicationUser>> changedEntries) : base(changedEntries)
        {
        }
    }
}
