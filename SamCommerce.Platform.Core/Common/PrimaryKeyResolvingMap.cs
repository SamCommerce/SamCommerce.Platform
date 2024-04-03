using SamCommerce.Platform.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamCommerce.Platform.Core.Common
{
    /// <summary>
    /// Helper class used for resolving model object primary keys when it persisted in persistent infrastructure
    /// Used in model to db model converters
    /// </summary>
    public class PrimaryKeyResolvingMap
    {
        private readonly Dictionary<IEntity, IEntity> _resolvingMap = new Dictionary<IEntity, IEntity>();

        public void AddPair(IEntity transientEntity, IEntity persistentEntity)
        {
            _resolvingMap[transientEntity] = persistentEntity;
        }

        public void ResolvePrimaryKeys()
        {
            foreach (var pair in _resolvingMap)
            {
                if (string.IsNullOrEmpty(pair.Key.Id) && !string.IsNullOrEmpty(pair.Value.Id))
                {
                    pair.Key.Id = pair.Value.Id;

                    if (pair.Key is IAuditable transientAuditable && pair.Value is IAuditable persistentAuditable)
                    {
                        transientAuditable.CreatedBy = persistentAuditable.CreatedBy;
                        transientAuditable.CreatedDate = persistentAuditable.CreatedDate;
                        transientAuditable.ModifiedBy = persistentAuditable.ModifiedBy;
                        transientAuditable.ModifiedDate = persistentAuditable.ModifiedDate;
                    }
                }
            }
        }
    }
}
