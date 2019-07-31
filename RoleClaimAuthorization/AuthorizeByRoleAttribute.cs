using System.Linq;
using System.Security.Claims;

namespace System.Web.Mvc
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class AuthorizeByRoleAttribute : System.Web.Mvc.AuthorizeAttribute
    {
        #region Constructors

        public AuthorizeByRoleAttribute() { }
        
        public AuthorizeByRoleAttribute(string roles)
        {
            Roles = roles;
        }

        public AuthorizeByRoleAttribute(string[] roles)
        {
            Roles = string.Join(",", roles);
        }
    
        #endregion

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var principal = filterContext.RequestContext.HttpContext.User;

            if (principal is ClaimsPrincipal)
            {
                var roles = Roles.Split(',').Select(r => r.Trim()).ToArray();
                if (((ClaimsPrincipal)principal).Claims.Where(c => c.Type == ClaimTypes.Role)
                    .Any(claim => roles.Any(r => r == claim.Value)))
                    return;
            }

            filterContext.Result = new HttpUnauthorizedResult();
        }
    }
}
