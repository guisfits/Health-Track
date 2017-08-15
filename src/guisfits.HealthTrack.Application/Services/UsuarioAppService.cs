using guisfits.HealthTrack.Application.Interfaces;
using System;
using System.Collections.Generic;
using guisfits.HealthTrack.Application.ViewModels;
using AutoMapper;
using guisfits.HealthTrack.Domain.Models;
using guisfits.HealthTrack.Infra.Data.Repository;

namespace guisfits.HealthTrack.Application.Services
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly UsuarioRepository usuarioRepository;

        public UsuarioAppService()
        {
            usuarioRepository = new UsuarioRepository();
        }

        public UsuarioViewModel Adicionar(UsuarioViewModel obj)
        {
            var usuario = Mapper.Map<Usuario>(obj);
            usuario.PesoAtual = obj.PesoAtual;
            usuarioRepository.Adicionar(usuario);
            return obj;
        }

        public UsuarioViewModel Atualizar(UsuarioViewModel obj)
        {
            //var usuario = Mapper.Map<Usuario>(obj);
            //usuario.PesoAtual = obj.PesoAtual;
            //usuarioRepository.Atualizar(usuario);
            usuarioRepository.Atualizar(Mapper.Map<Usuario>(obj));
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
            usuarioRepository.Remover(id);
        }

        public void Dispose()
        {
            usuarioRepository.Dispose();
        }
    }
}
