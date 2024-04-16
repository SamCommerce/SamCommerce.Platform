using SamCommerce.Platform.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamCommerce.Platform.Core.Events
{
    public interface IEventHandler<in T> : IHandler<T> where T : IEvent
    {
    }
}
