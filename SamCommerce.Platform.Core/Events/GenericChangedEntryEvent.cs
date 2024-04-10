using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SamCommerce.Platform.Core.Events
{
    public class GenericChangedEntryEvent<T> : DomainEvent
    {
        [JsonConstructor]
        public GenericChangedEntryEvent(IEnumerable<GenericChangedEntry<T>> changedEntries)
        {
            ChangedEntries = changedEntries;
        }

        public IEnumerable<GenericChangedEntry<T>> ChangedEntries { get; private set; }
    }
}
