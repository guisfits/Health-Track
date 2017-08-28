using System;
using System.Collections.Generic;
using System.Web.Http;
using guisfits.HealthTrack.Application.Interfaces;
using guisfits.HealthTrack.Application.ViewModels;

namespace guisfits.HealthTrack.Services.WebAPI.Controllers
{
    public class UsuariosController : ApiController
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public UsuariosController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        public IEnumerable<UsuarioViewModel> Get()
        {
            return _usuarioAppService.ObterTodos();
        }

        public UsuarioViewModel Get(Guid id)
        {
            return _usuarioAppService.ObterPorId(id);
        }

        public IHttpActionResult Post([FromBody]UsuarioViewModel value)
        {
            var result = _usuarioAppService.Adicionar(value).ValidationResult;
            return result.IsValid ? (IHttpActionResult) Ok() : BadRequest();
        }

        public IHttpActionResult Put(Guid id, [FromBody]UsuarioViewModel value)
        {
            var result = _usuarioAppService.Atualizar(value).ValidationResult;
            return result.IsValid ? (IHttpActionResult)Ok() : BadRequest();
        }

        public void Delete(Guid id)
        {
            _usuarioAppService.Remover(id);
        }
    }
}
