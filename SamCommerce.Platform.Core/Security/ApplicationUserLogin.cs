using SamCommerce.Platform.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamCommerce.Platform.Core.Security
{
    public class ApplicationUserLogin : ValueObject
    {
        public virtual string LoginProvider { get; set; }
        public virtual string ProviderKey { get; set; }
    }
}
