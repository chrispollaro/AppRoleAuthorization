using System.Security.Principal;
using System.Web.Mvc;

namespace TestWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var state = User.HasRoleClaim("Admin");
            if (state)
            {
                return RedirectToAction(nameof(About));
            }

            return View();
        }

        [AuthorizeByRole(Roles = "TestRole")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [AuthorizeByRole("Admin")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}