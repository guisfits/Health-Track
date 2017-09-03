using System;
using System.Net;
using System.Web.Mvc;
using guisfits.HealthTrack.Application.Interfaces;
using guisfits.HealthTrack.Application.ViewModels;
using Microsoft.AspNet.Identity;

namespace guisfits.HealthTrack.Presentation.Controllers
{
    [Authorize]
    public class ExercicioFisicoController : Controller
    {
        private readonly IExercicioFisicoAppService _exercicioAppService;
        private readonly IUsuarioAppService _usuarioAppService;

        public ExercicioFisicoController(IExercicioFisicoAppService exercicioAppService, IUsuarioAppService usuarioAppService)
        {
            _exercicioAppService = exercicioAppService;
            _usuarioAppService = usuarioAppService;
        }

        public ActionResult Index()
        {
            var identityId = HttpContext.User.Identity.GetUserId();
            var id = _usuarioAppService.ObterIdPeloIdentity(identityId);
            var exercicio = _exercicioAppService.ObterTodosPorUsuario(id);
            return View(exercicio);
        }

        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExercicioFisicoViewModel exercicioFisicoViewModel = _exercicioAppService.ObterPorId(id.Value);
            if (exercicioFisicoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(exercicioFisicoViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExercicioFisicoViewModel exercicioFisicoViewModel)
        {
            if (!ModelState.IsValid)
                return View(exercicioFisicoViewModel);

            var identityId = HttpContext.User.Identity.GetUserId();
            exercicioFisicoViewModel.UsuarioId = _usuarioAppService.ObterIdPeloIdentity(identityId);
            exercicioFisicoViewModel = _exercicioAppService.Adicionar(exercicioFisicoViewModel);
            var result = exercicioFisicoViewModel.ValidationResult;

            if (!result.IsValid)
            {
                foreach (var erro in result.Erros)
                    ModelState.AddModelError(string.Empty, erro.Message);

                return View(exercicioFisicoViewModel);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExercicioFisicoViewModel exercicioFisicoViewModel = _exercicioAppService.ObterPorId(id.Value);
            if (exercicioFisicoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(exercicioFisicoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ExercicioFisicoViewModel exercicioFisicoViewModel)
        {
            if (ModelState.IsValid)
            {
                var identityId = HttpContext.User.Identity.GetUserId();
                exercicioFisicoViewModel.UsuarioId = _usuarioAppService.ObterIdPeloIdentity(identityId);
                _exercicioAppService.Atualizar(exercicioFisicoViewModel);
                return RedirectToAction("Index");
            }
            return View(exercicioFisicoViewModel);
        }

        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExercicioFisicoViewModel exercicioFisicoViewModel = _exercicioAppService.ObterPorId(id.Value);
            if (exercicioFisicoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(exercicioFisicoViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _exercicioAppService.Remover(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _exercicioAppService.Dispose();
                _usuarioAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
