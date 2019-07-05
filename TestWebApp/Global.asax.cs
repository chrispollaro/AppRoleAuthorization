using System.Linq;
using System.Security.Claims;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace TestWebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_AuthorizeRequest()
        {
            if (Request.IsAuthenticated)
            {
                ClaimsIdentity ci = ClaimsPrincipal.Current.Identities.First();

                ci.AddClaim(new Claim(ClaimTypes.Role, "Admin"));
                ci.AddClaim(new Claim(ClaimTypes.Role, "TestRole"));
            }
        }
    }
}
