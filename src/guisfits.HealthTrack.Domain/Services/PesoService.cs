using System;
using System.Collections.Generic;
using guisfits.HealthTrack.Domain.Interfaces.Repository;
using guisfits.HealthTrack.Domain.Interfaces.Services;
using guisfits.HealthTrack.Domain.Models;

namespace guisfits.HealthTrack.Domain.Services
{
    public class PesoService : EntityService<Peso>, IPesoService
    {
        private IPesoRepository _repository;

        public PesoService(IPesoRepository repository) 
            : base(repository)
        {
            _repository = repository;
        }

        public IEnumerable<Peso> ObterTodosPorUsuario(Guid id)
        {
            return _repository.ObterTodosPorUsuario(id);
        }
    }
}
