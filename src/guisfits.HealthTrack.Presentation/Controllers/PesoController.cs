using System;
using System.Net;
using System.Web.Mvc;
using guisfits.HealthTrack.Application.Interfaces;
using guisfits.HealthTrack.Application.ViewModels;
using Microsoft.AspNet.Identity;

namespace guisfits.HealthTrack.Presentation.Controllers
{
    [Authorize]
    public class PesoController : Controller
    {
        private readonly IPesoAppService _pesoAppService;
        private readonly IUsuarioAppService _usuarioAppService;

        public PesoController(IPesoAppService pesoAppService, IUsuarioAppService usuarioAppService)
        {
            _pesoAppService = pesoAppService;
            _usuarioAppService = usuarioAppService;
        }

        public ActionResult Index()
        {
            var identityId = HttpContext.User.Identity.GetUserId();
            var id = _usuarioAppService.ObterIdPeloIdentity(identityId);
            var peso = _pesoAppService.ObterTodosPorUsuario(id);
            return View(peso);
        }

        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PesoViewModel pesoViewModel = _pesoAppService.ObterPorId(id.Value);
            if (pesoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(pesoViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PesoViewModel pesoViewModel)
        {
            if (!ModelState.IsValid)
                return View(pesoViewModel);

            var identityId = HttpContext.User.Identity.GetUserId();
            pesoViewModel.UsuarioId = _usuarioAppService.ObterIdPeloIdentity(identityId);
            pesoViewModel = _pesoAppService.Adicionar(pesoViewModel);
            var result = pesoViewModel.ValidationResult;

            if (!result.IsValid)
            {
                foreach (var erro in result.Erros)
                    ModelState.AddModelError(string.Empty, erro.Message);

                return View(pesoViewModel);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PesoViewModel pesoViewModel = _pesoAppService.ObterPorId(id.Value);
            if (pesoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(pesoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PesoViewModel pesoViewModel)
        {
            if (ModelState.IsValid)
            {
                var identityId = HttpContext.User.Identity.GetUserId();
                pesoViewModel.UsuarioId = _usuarioAppService.ObterIdPeloIdentity(identityId);
                _pesoAppService.Atualizar(pesoViewModel);
                return RedirectToAction("Index");
            }
            return View(pesoViewModel);
        }

        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PesoViewModel pesoViewModel = _pesoAppService.ObterPorId(id.Value);
            if (pesoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(pesoViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _pesoAppService.Remover(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _pesoAppService.Dispose();
                _usuarioAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
