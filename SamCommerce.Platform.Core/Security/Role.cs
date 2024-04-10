using Microsoft.AspNetCore.Identity;
using SamCommerce.Platform.Core.Extensions;
using SamCommerce.Platform.Core.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SamCommerce.Platform.Core.Security
{
    public class Role : IdentityRole, ICloneable
    {
        public Role()
        {
            Permissions = new List<Permission>();
        }

        public string Description { get; set; }
        public IList<Permission> Permissions { get; set; }

        [SwaggerIgnore]
        public ICollection<IdentityUserRole<string>> UserRoles { get; set; }

        public virtual void Patch(Role target)
        {
            target.Name = Name;
            target.NormalizedName = NormalizedName;
            target.ConcurrencyStamp = ConcurrencyStamp;
            target.Description = Description;

            if (!Permissions.IsNullCollection())
            {
                Permissions.Patch(target.Permissions, (sourcePermission, targetPermission) => sourcePermission.Patch(targetPermission));
            }
        }

        #region ICloneable members
        public virtual object Clone()
        {
            var result = MemberwiseClone() as Role;

            result.Permissions = Permissions?.Select(x => x.Clone()).OfType<Permission>().ToList();

            return result;
        }
        #endregion
    }
}
