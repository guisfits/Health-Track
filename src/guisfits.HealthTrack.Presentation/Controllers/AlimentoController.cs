using System;
using System.Net;
using System.Web.Mvc;
using guisfits.HealthTrack.Application.Interfaces;
using guisfits.HealthTrack.Application.ViewModels;
using Microsoft.AspNet.Identity;

namespace guisfits.HealthTrack.Presentation.Controllers
{
    [Authorize]
    public class AlimentoController : Controller
    {
        private readonly IAlimentoAppService _alimentoService;
        private readonly IUsuarioAppService _usuarioAppService;

        public AlimentoController(IAlimentoAppService alimentoService, IUsuarioAppService usuarioAppService)
        {
            _alimentoService = alimentoService;
            _usuarioAppService = usuarioAppService;
        }

        public ActionResult Index()
        {
            var identityId = HttpContext.User.Identity.GetUserId();
            var id = _usuarioAppService.ObterIdPeloIdentity(identityId);
            var alimentos = _alimentoService.ObterTodosPorUsuario(id);
            return View(alimentos);
        }

        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlimentoViewModel alimentoViewModel = _alimentoService.ObterPorId(id.Value);
            if (alimentoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(alimentoViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AlimentoViewModel alimentoViewModel)
        {
            if (!ModelState.IsValid)
                return View(alimentoViewModel);

            var identityId = HttpContext.User.Identity.GetUserId();
            alimentoViewModel.UsuarioId = _usuarioAppService.ObterIdPeloIdentity(identityId);
            alimentoViewModel = _alimentoService.Adicionar(alimentoViewModel);
            var result = alimentoViewModel.ValidationResult;

            if (!result.IsValid)
            {
                foreach (var erro in result.Erros)
                    ModelState.AddModelError(string.Empty, erro.Message);

                return View(alimentoViewModel);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlimentoViewModel alimentoViewModel = _alimentoService.ObterPorId(id.Value);
            if (alimentoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(alimentoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AlimentoViewModel alimentoViewModel)
        {
            if (ModelState.IsValid)
            {
                var identityId = HttpContext.User.Identity.GetUserId();
                alimentoViewModel.UsuarioId = _usuarioAppService.ObterIdPeloIdentity(identityId);
                _alimentoService.Atualizar(alimentoViewModel);
                return RedirectToAction("Index");
            }
            return View(alimentoViewModel);
        }

        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlimentoViewModel alimentoViewModel = _alimentoService.ObterPorId(id.Value);
            if (alimentoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(alimentoViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _alimentoService.Remover(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _alimentoService.Dispose();
                _usuarioAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
