using SamCommerce.Platform.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamCommerce.Platform.Core.DynamicProperties
{
    public interface IHasDynamicProperties : IEntity
    {
        string ObjectType { get; }
        ICollection<DynamicObjectProperty> DynamicProperties { get; set; }
    }
}
