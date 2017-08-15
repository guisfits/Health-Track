using System;
using System.Net;
using System.Web.Mvc;
using guisfits.HealthTrack.Application.ViewModels;
using guisfits.HealthTrack.Application.Interfaces;
using guisfits.HealthTrack.Application.Services;

namespace guisfits.HealthTrack.Presentation.Controllers
{
    public class UsuariosController : Controller
    {
        private IUsuarioAppService usuarioAppService;

        public UsuariosController()
        {
            usuarioAppService = new UsuarioAppService();
        }

        public ActionResult Index()
        {
            return View(usuarioAppService.ObterTodos());
        }

        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioViewModel usuarioViewModel = usuarioAppService.ObterPorId(id.Value);
            if (usuarioViewModel == null)
            {
                return HttpNotFound();
            }
            return View(usuarioViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Sobrenome,Email,Sexo,AlturaMetros,Nascimento,PesoAtual,Excluido")] UsuarioViewModel usuarioViewModel)
        {
            if (ModelState.IsValid)
            {
                usuarioViewModel.Id = Guid.NewGuid();
                usuarioAppService.Adicionar(usuarioViewModel);
                return RedirectToAction("Index");
            }

            return View(usuarioViewModel);
        }

        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioViewModel usuarioViewModel = usuarioAppService.ObterPorId(id.Value);
            if (usuarioViewModel == null)
            {
                return HttpNotFound();
            }
            return View(usuarioViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsuarioViewModel usuarioViewModel)
        {
            if (ModelState.IsValid)
            {
                usuarioAppService.Atualizar(usuarioViewModel);
                return RedirectToAction("Index");
            }
            return View(usuarioViewModel);
        }

        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioViewModel usuarioViewModel = usuarioAppService.ObterPorId(id.Value);
            if (usuarioViewModel == null)
            {
                return HttpNotFound();
            }
            return View(usuarioViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid? id)
        {
            UsuarioViewModel usuarioViewModel = usuarioAppService.ObterPorId(id.Value);
            usuarioAppService.Remover(id.Value);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                usuarioAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
