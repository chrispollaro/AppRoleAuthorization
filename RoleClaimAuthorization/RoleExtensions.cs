using System.Linq;
using System.Security.Claims;

namespace System.Security.Principal
{
    public static class PrincipalExtensions
    {
        public static bool HasRoleClaim(this IPrincipal principal, string role)
        {
            var cp = principal as ClaimsPrincipal;
            if (cp != null)
            {
                return cp.Claims.Where(c => c.Type == ClaimTypes.Role).Any(claim => claim.Value == role);
            }
            
            return false;
        }
    }
}
