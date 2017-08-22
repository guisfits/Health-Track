using System;
using guisfits.HealthTrack.Domain.Interfaces.Repository;
using guisfits.HealthTrack.Domain.Interfaces.Services;
using guisfits.HealthTrack.Domain.Models;

namespace guisfits.HealthTrack.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Usuario Adicionar(Usuario usuario)
        {
            return _usuarioRepository.Adicionar(usuario);
        }

        public Usuario Atualizar(Usuario usuario)
        {
            return _usuarioRepository.Atualizar(usuario);
        }

        public void Remover(Guid id)
        {
            _usuarioRepository.Remover(id);
        }

        public void Dispose()
        {
            _usuarioRepository.Dispose();
        }
    }
}
