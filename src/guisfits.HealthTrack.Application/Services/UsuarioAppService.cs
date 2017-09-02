using guisfits.HealthTrack.Application.Interfaces;
using System;
using System.Collections.Generic;
using guisfits.HealthTrack.Application.ViewModels;
using AutoMapper;
using guisfits.HealthTrack.Domain.Interfaces.Services;
using guisfits.HealthTrack.Domain.Models;
using guisfits.HealthTrack.Infra.Data.UoW;

namespace guisfits.HealthTrack.Application.Services
{
    public class UsuarioAppService : AppService, IUsuarioAppService
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioAppService(IUsuarioService usuarioService,
                                 IUnitOfWork uow)
            :base(uow)
        {
            _usuarioService = usuarioService;
        }

        public UsuarioViewModel Adicionar(UsuarioViewModel obj)
        {
            var usuario = Mapper.Map<Usuario>(obj);
            usuario.PesoAtual = obj.PesoAtual;
            var result = _usuarioService.Adicionar(usuario);

            if (result.EhValido())
                Commit();

            return Mapper.Map<UsuarioViewModel>(result);
        }

        public UsuarioViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<UsuarioViewModel>(_usuarioService.ObterPorId(id));
        }

        public IEnumerable<UsuarioViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<UsuarioViewModel>>(_usuarioService.ObterTodos());
        }

        public IEnumerable<UsuarioViewModel> ObterPaginado(int s, int t)
        {
            return Mapper.Map<IEnumerable<UsuarioViewModel>>(_usuarioService.ObterPaginado(s, t));
        }

        public UsuarioViewModel Atualizar(UsuarioViewModel obj)
        {
            var result = _usuarioService.Atualizar(Mapper.Map<Usuario>(obj));

            if (result.EhValido())
                Commit();

            return Mapper.Map<UsuarioViewModel>(result);
        }

        public void Remover(Guid id)
        {
            _usuarioService.Remover(id);
            Commit();
        }

        public Guid ObterIdPeloIdentity(string idIdentity)
        {
            return _usuarioService.ObterIdPeloIdentity(idIdentity);
        }

        public void Dispose()
        {
            _usuarioService.Dispose();
        }
    }
}
