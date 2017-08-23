using guisfits.HealthTrack.Application.Interfaces;
using System;
using System.Collections.Generic;
using guisfits.HealthTrack.Application.ViewModels;
using AutoMapper;
using guisfits.HealthTrack.Domain.Interfaces.Repository;
using guisfits.HealthTrack.Domain.Interfaces.Services;
using guisfits.HealthTrack.Domain.Models;

namespace guisfits.HealthTrack.Application.Services
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IUsuarioService usuarioService;

        public UsuarioAppService(IUsuarioRepository usuarioRepository, IUsuarioService usuarioService)
        {
            this.usuarioRepository = usuarioRepository;
            this.usuarioService = usuarioService;
        }

        public UsuarioViewModel Adicionar(UsuarioViewModel obj)
        {
            var usuario = Mapper.Map<Usuario>(obj);
            usuario.PesoAtual = obj.PesoAtual;

            var result = usuarioService.Adicionar(usuario);
            obj = Mapper.Map<UsuarioViewModel>(result);

            return obj;
        }

        public UsuarioViewModel Atualizar(UsuarioViewModel obj)
        {
            usuarioService.Atualizar(Mapper.Map<Usuario>(obj));
            return obj;
        }

        public IEnumerable<UsuarioViewModel> ObterPaginado(int s, int t)
        {
            return Mapper.Map<IEnumerable<UsuarioViewModel>>(usuarioRepository.ObterPaginado(s, t));
        }

        public UsuarioViewModel ObterPorId(Guid id)
        {
            var usuario = Mapper.Map<UsuarioViewModel>(usuarioRepository.ObterPorId(id));
            return usuario;
        }

        public IEnumerable<UsuarioViewModel> ObterTodos()
        {
            //return _clienteRepository.ObterAtivos().ProjectTo<ClienteViewModel>();
            return Mapper.Map<IEnumerable<UsuarioViewModel>>(usuarioRepository.ObterTodos());
        }

        public void Remover(Guid id)
        {
            usuarioService.Remover(id);
        }

        public void Dispose()
        {
            usuarioRepository.Dispose();
            usuarioService.Dispose();
        }
    }
}
