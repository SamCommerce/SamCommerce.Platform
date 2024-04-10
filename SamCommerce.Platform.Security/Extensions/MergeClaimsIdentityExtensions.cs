using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SamCommerce.Platform.Security.Extensions
{
    public static class MergeClaimsIdentityExtensions
    {
        public static void MergeAllClaims(this ClaimsIdentity destination, ClaimsIdentity source)
        {
            foreach (var claim in source.Claims
                         .Where(claim => !destination.HasClaim(claim.Type, claim.Value)))
            {
                destination.AddClaim(new Claim(claim.Type, claim.Value));
            }
        }
    }
}
