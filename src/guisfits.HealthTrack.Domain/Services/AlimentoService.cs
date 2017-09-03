using System;
using System.Collections.Generic;
using guisfits.HealthTrack.Domain.Interfaces.Repository;
using guisfits.HealthTrack.Domain.Interfaces.Services;
using guisfits.HealthTrack.Domain.Models;

namespace guisfits.HealthTrack.Domain.Services
{
    public class AlimentoService : EntityService<Alimento>, IAlimentoService
    {
        private IAlimentoRepository _repository;

        public AlimentoService(IAlimentoRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

        public IEnumerable<Alimento> ObterTodosPorUsuario(Guid id)
        {
            return _repository.ObterTodosPorUsuario(id);
        }
    }
}
