using System;
using guisfits.HealthTrack.Domain.Interfaces.Repository;
using guisfits.HealthTrack.Domain.Interfaces.Services;
using guisfits.HealthTrack.Domain.Models;

namespace guisfits.HealthTrack.Domain.Services
{
    public class UsuarioService : EntityService<Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository) 
            : base(repository)
        {
            _repository = repository;
        }

        public Guid ObterIdPeloIdentity(string idIdentity)
        {
            return _repository.ObterIdPeloIdentity(idIdentity);
        }
    }
}
