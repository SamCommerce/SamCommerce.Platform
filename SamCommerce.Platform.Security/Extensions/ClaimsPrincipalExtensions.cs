using OpenIddict.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SamCommerce.Platform.Security.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetAuthenticationMethod(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.GetClaim(ClaimTypes.AuthenticationMethod);
        }

        public static bool IsSsoAuthenticationMethod(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.GetClaim(ClaimTypes.AuthenticationMethod) != null;
        }
    }
}
