using System.Web.Mvc;

namespace guisfits.HealthTrack.Presentation.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index(int? code)
        {
            return View("Error");
        }

        public ActionResult NotFound()
        {
            return View("NotFound");
        }

        public ActionResult AccessDenied()
        {
            return View("AccessDenied");
        }
    }
}