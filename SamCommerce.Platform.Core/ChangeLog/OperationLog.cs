using SamCommerce.Platform.Core.Common;
using SamCommerce.Platform.Core.Domain;
using SamCommerce.Platform.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamCommerce.Platform.Core.ChangeLog
{
    public class OperationLog : AuditableEntity, ICloneable
    {
        public string ObjectType { get; set; }

        public string ObjectId { get; set; }

        public EntryState OperationType { get; set; }

        public string Detail { get; set; }

        public virtual OperationLog FromChangedEntry<T>(GenericChangedEntry<T> changedEntry) where T : IEntity
        {
            if (changedEntry == null)
            {
                throw new ArgumentNullException(nameof(changedEntry));
            }

            return FromChangedEntry(changedEntry, changedEntry.OldEntry.GetType().Name);
        }

        public virtual OperationLog FromChangedEntry<T>(GenericChangedEntry<T> changedEntry, string objectType) where T : IEntity
        {
            if (changedEntry == null)
            {
                throw new ArgumentNullException(nameof(changedEntry));
            }

            ObjectId = changedEntry.OldEntry.Id;
            ObjectType = objectType;
            OperationType = changedEntry.EntryState;

            return this;
        }

        #region ICloneable members

        public virtual object Clone()
        {
            return MemberwiseClone() as OperationLog;
        }

        #endregion
    }
}
