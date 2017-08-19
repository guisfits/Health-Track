using System;
using System.Net;
using System.Web.Mvc;
using guisfits.HealthTrack.Application.ViewModels;
using guisfits.HealthTrack.Application.Interfaces;
using guisfits.HealthTrack.Application.Services;
using guisfits.HealthTrack.CrossCutting.MvcFilters;

namespace guisfits.HealthTrack.Presentation.Controllers
{
    [RoutePrefix("perfil")]
    [Authorize]
    public class UsuariosController : Controller
    {
        private IUsuarioAppService usuarioAppService;

        
        public UsuariosController()
        {
            usuarioAppService = new UsuarioAppService();
        }

        [Route("listar-todos-clientes")]
        [AllowAnonymous]
        [ClaimsAuthorize("Usuarios", "VI")]
        public ActionResult Index()
        {
            return View(usuarioAppService.ObterTodos());
        }

        [Route("sobre-cliente")]
        [ClaimsAuthorize("Usuarios", "DE")]
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

        [Route("criar-novo-cliente")]
        [ClaimsAuthorize("Usuarios", "CE")]
        public ActionResult Create()
        {
            return View();
        }

        [Route("criar-novo-cliente")]
        [ClaimsAuthorize("Usuarios", "CE")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Sobrenome,Email,Sexo,AlturaMetros,Nascimento,PesoAtual")] UsuarioViewModel usuarioViewModel)
        {
            if (ModelState.IsValid)
            {
                usuarioViewModel.Id = Guid.NewGuid();
                usuarioAppService.Adicionar(usuarioViewModel);
                return RedirectToAction("Index");
            }

            return View(usuarioViewModel);
        }

        [Route("{id:guid}/alterar-cliente")]
        [ClaimsAuthorize("Usuarios", "ED")]
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

        [Route("{id:guid}/alterar-cliente")]
        [ClaimsAuthorize("Usuarios", "ED")]
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

        [Route("{id:guid}/excluir-cliente")]
        [ClaimsAuthorize("Usuarios", "EX")]
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

        [Route("{id:guid}/excluir-cliente")]
        [ClaimsAuthorize("Usuarios", "EX")]
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
