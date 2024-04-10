﻿using SamCommerce.Platform.Core.Common;
using SamCommerce.Platform.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamCommerce.Platform.Core.Events
{
    public interface IEvent : IEntity, IMessage
    {
        int Version { get; set; }
        DateTimeOffset TimeStamp { get; set; }
    }
}