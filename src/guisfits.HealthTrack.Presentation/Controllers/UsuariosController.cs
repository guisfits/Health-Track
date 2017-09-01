//using System;
//using System.Net;
//using System.Web.Mvc;
//using guisfits.HealthTrack.Application.ViewModels;
//using guisfits.HealthTrack.Application.Interfaces;
//using guisfits.HealthTrack.CrossCutting.MvcFilters;

//namespace guisfits.HealthTrack.Presentation.Controllers
//{
//    [RoutePrefix("perfil")]
//    [Authorize]
//    public class UsuariosController : Controller
//    {
//        private readonly IUsuarioAppService _usuarioAppService;

//        public UsuariosController(IUsuarioAppService usuarioAppService)
//        {
//            this._usuarioAppService = usuarioAppService;
//        }

//        [Route("listar-todos-clientes")]
//        [ClaimsAuthorize("Usuarios", "VI")]
//        public ActionResult Index()
//        {
//            return View(_usuarioAppService.ObterTodos());
//        }

//        [Route("sobre-cliente")]
//        [ClaimsAuthorize("Usuarios", "DE")]
//        public ActionResult Details(Guid? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            UsuarioViewModel usuarioViewModel = _usuarioAppService.ObterPorId(id.Value);
//            if (usuarioViewModel == null)
//            {
//                return HttpNotFound();
//            }
//            return View(usuarioViewModel);
//        }

//        [Route("criar-novo-cliente")]
//        [ClaimsAuthorize("Usuarios", "CE")]
//        public ActionResult Create()
//        {
//            return View();
//        }

//        [Route("criar-novo-cliente")]
//        [ClaimsAuthorize("Usuarios", "CE")]
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "Id,Nome,Sobrenome,Email,Sexo,Altura,Nascimento,PesoAtual")] UsuarioViewModel usuarioViewModel)
//        {
//            if (!ModelState.IsValid)
//                return View(usuarioViewModel);

//            usuarioViewModel = _usuarioAppService.Adicionar(usuarioViewModel);
//            var result = usuarioViewModel.ValidationResult;

//            if (!result.IsValid)
//            {
//                foreach (var erro in result.Erros)
//                    ModelState.AddModelError(string.Empty, erro.Message);

//                return View(usuarioViewModel);
//            }

//            return RedirectToAction("Index");
//        }

//        [Route("{id:guid}/alterar-cliente")]
//        [ClaimsAuthorize("Usuarios", "ED")]
//        public ActionResult Edit(Guid? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            UsuarioViewModel usuarioViewModel = _usuarioAppService.ObterPorId(id.Value);
//            if (usuarioViewModel == null)
//            {
//                return HttpNotFound();
//            }
//            return View(usuarioViewModel);
//        }

//        [Route("{id:guid}/alterar-cliente")]
//        [ClaimsAuthorize("Usuarios", "ED")]
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit(UsuarioViewModel usuarioViewModel)
//        {
//            if (ModelState.IsValid)
//            {
//                _usuarioAppService.Atualizar(usuarioViewModel);
//                return RedirectToAction("Index");
//            }
//            return View(usuarioViewModel);
//        }

//        [Route("{id:guid}/excluir-cliente")]
//        [ClaimsAuthorize("Usuarios", "EX")]
//        public ActionResult Delete(Guid? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            UsuarioViewModel usuarioViewModel = _usuarioAppService.ObterPorId(id.Value);
//            if (usuarioViewModel == null)
//            {
//                return HttpNotFound();
//            }
//            return View(usuarioViewModel);
//        }

//        [Route("{id:guid}/excluir-cliente")]
//        [ClaimsAuthorize("Usuarios", "EX")]
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(Guid? id)
//        {
//            _usuarioAppService.Remover(id.Value);
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                _usuarioAppService.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}
