using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamCommerce.Platform.Core.Events
{
    public interface IEventPublisher
    {
        Task Publish<T>(T @event, CancellationToken cancellationToken = default) where T : IEvent;
    }
}
