using SamCommerce.Platform.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamCommerce.Platform.Core.Events
{
    public class DomainEvent : Entity, IEvent
    {
        public DomainEvent()
        {
            Id = Guid.NewGuid().ToString();
            TimeStamp = DateTime.UtcNow;
        }
        public int Version { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
    }
}
