using guisfits.HealthTrack.Application.Interfaces;
using System;
using System.Collections.Generic;
using guisfits.HealthTrack.Application.ViewModels;
using AutoMapper;
using guisfits.HealthTrack.Domain.Interfaces.Repository;
using guisfits.HealthTrack.Domain.Interfaces.Services;
using guisfits.HealthTrack.Domain.Models;
using guisfits.HealthTrack.Infra.Data.UoW;

namespace guisfits.HealthTrack.Application.Services
{
    public class UsuarioAppService : AppService, IUsuarioAppService
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IUsuarioService usuarioService;

        public UsuarioAppService(IUsuarioRepository usuarioRepository, 
                                 IUsuarioService usuarioService,
                                 IUnitOfWork uow)
            :base(uow)
        {
            this.usuarioRepository = usuarioRepository;
            this.usuarioService = usuarioService;
        }

        public UsuarioViewModel Adicionar(UsuarioViewModel obj)
        {
            var usuario = Mapper.Map<Usuario>(obj);
            usuario.PesoAtual = obj.PesoAtual;
            var result = usuarioService.Adicionar(usuario);

            if (result.ValidationResult.IsValid)
                this.Commit();
            

            obj = Mapper.Map<UsuarioViewModel>(result);
            return obj;
        }

        public UsuarioViewModel Atualizar(UsuarioViewModel obj)
        {
            var result = usuarioService.Atualizar(Mapper.Map<Usuario>(obj));

            if (result.ValidationResult.IsValid)
                this.Commit();

            return obj;
        }

        public UsuarioViewModel ObterPorId(Guid id)
        {
            var usuario = Mapper.Map<UsuarioViewModel>(usuarioRepository.ObterPorId(id));
            return usuario;
        }

        public IEnumerable<UsuarioViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<UsuarioViewModel>>(usuarioRepository.ObterTodos());
        }

        public IEnumerable<UsuarioViewModel> ObterPaginado(int s, int t)
        {
            return Mapper.Map<IEnumerable<UsuarioViewModel>>(usuarioRepository.ObterPaginado(s, t));
        }

        public void Remover(Guid id)
        {
            usuarioService.Remover(id);
            this.Commit();
        }

        public void Dispose()
        {
            usuarioRepository.Dispose();
            usuarioService.Dispose();
        }
    }
}
