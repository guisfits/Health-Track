using System.Web.Mvc;
using guisfits.HealthTrack.Application.Interfaces;
using Microsoft.AspNet.Identity;

namespace guisfits.HealthTrack.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public HomeController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        [Authorize]
        public ActionResult Dashboard()
        {
            var idIdentity = HttpContext.User.Identity.GetUserId();
            var id = _usuarioAppService.ObterIdPeloIdentity(idIdentity);
            return View(_usuarioAppService.ObterPorId(id));
        }
    }
}