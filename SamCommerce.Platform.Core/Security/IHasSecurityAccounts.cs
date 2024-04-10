using SamCommerce.Platform.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamCommerce.Platform.Core.Security
{
    public interface IHasSecurityAccounts : IEntity
    {
        /// <summary>
        /// All security accounts 
        /// </summary>
        ICollection<ApplicationUser> SecurityAccounts { get; set; }
    }
}

