using SamCommerce.Platform.Core.Common;
using SamCommerce.Platform.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SamCommerce.Platform.Core.Events
{
    public class GenericChangedEntry<T> : ValueObject
    {
        public GenericChangedEntry(T entry, EntryState state)
            : this(entry, entry, state)
        {
        }

        [JsonConstructor]
        public GenericChangedEntry(T newEntry, T oldEntry, EntryState entryState)
        {
            NewEntry = newEntry;
            OldEntry = oldEntry;
            EntryState = entryState;
        }

        public EntryState EntryState { get; set; }
        public T NewEntry { get; set; }
        public T OldEntry { get; set; }
    }
}