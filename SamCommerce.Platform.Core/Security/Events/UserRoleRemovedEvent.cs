using SamCommerce.Platform.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamCommerce.Platform.Core.Security.Events
{
    public class UserRoleRemovedEvent : DomainEvent
    {
        public UserRoleRemovedEvent(ApplicationUser user, string role)
        {
            User = user;
            Role = role;
        }

        public ApplicationUser User { get; set; }
        public string Role { get; set; }
    }
}
