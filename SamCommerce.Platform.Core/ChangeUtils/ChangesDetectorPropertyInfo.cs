using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SamCommerce.Platform.Core.ChangeUtils
{
    public sealed class ChangesDetectorPropertyInfo
    {
        public string PropertyName { get; set; }
        public bool Inherited { get; set; }
        public string ChangeKey { get; set; }
        public MethodInfo Getter { get; set; }
    }
}
