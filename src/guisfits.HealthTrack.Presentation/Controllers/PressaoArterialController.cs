using System;
using System.Net;
using System.Web.Mvc;
using guisfits.HealthTrack.Application.Interfaces;
using guisfits.HealthTrack.Application.ViewModels;
using Microsoft.AspNet.Identity;

namespace guisfits.HealthTrack.Presentation.Controllers
{
    [Authorize]
    public class PressaoArterialController : Controller
    {
        private readonly IPressaoArterialAppService _pressaoService;
        private readonly IUsuarioAppService _usuarioAppService;

        public PressaoArterialController(IPressaoArterialAppService pressaoService, IUsuarioAppService usuarioService)
        {
            _pressaoService = pressaoService;
            _usuarioAppService = usuarioService;
        }

        public ActionResult Index()
        {
            var identityId = HttpContext.User.Identity.GetUserId();
            var id = _usuarioAppService.ObterIdPeloIdentity(identityId);
            var pressao = _pressaoService.ObterTodosPorUsuario(id);
            return View(pressao);
        }

        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PressaoArterialViewModel pressaoArterialViewModel = _pressaoService.ObterPorId(id.Value);
            if (pressaoArterialViewModel == null)
            {
                return HttpNotFound();
            }
            return View(pressaoArterialViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PressaoArterialViewModel pressaoArterialViewModel)
        {
            if (!ModelState.IsValid)
                return View(pressaoArterialViewModel);

            var identityId = HttpContext.User.Identity.GetUserId();
            pressaoArterialViewModel.UsuarioId = _usuarioAppService.ObterIdPeloIdentity(identityId);
            pressaoArterialViewModel = _pressaoService.Adicionar(pressaoArterialViewModel);
            var result = pressaoArterialViewModel.ValidationResult;

            if (!result.IsValid)
            {
                foreach (var erro in result.Erros)
                    ModelState.AddModelError(string.Empty, erro.Message);

                return View(pressaoArterialViewModel);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PressaoArterialViewModel pressaoArterialViewModel = _pressaoService.ObterPorId(id.Value);
            if (pressaoArterialViewModel == null)
            {
                return HttpNotFound();
            }
            return View(pressaoArterialViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PressaoArterialViewModel pressaoArterialViewModel)
        {
            if (ModelState.IsValid)
            {
                var identityId = HttpContext.User.Identity.GetUserId();
                pressaoArterialViewModel.UsuarioId = _usuarioAppService.ObterIdPeloIdentity(identityId);
                _pressaoService.Atualizar(pressaoArterialViewModel);
                return RedirectToAction("Index");
            }
            return View(pressaoArterialViewModel);
        }

        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PressaoArterialViewModel pressaoArterialViewModel = _pressaoService.ObterPorId(id.Value);
            if (pressaoArterialViewModel == null)
            {
                return HttpNotFound();
            }
            return View(pressaoArterialViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _pressaoService.Remover(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _pressaoService.Dispose();
                _usuarioAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
