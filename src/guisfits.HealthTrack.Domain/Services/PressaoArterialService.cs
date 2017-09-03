using System;
using System.Collections.Generic;
using guisfits.HealthTrack.Domain.Interfaces.Repository;
using guisfits.HealthTrack.Domain.Interfaces.Services;
using guisfits.HealthTrack.Domain.Models;

namespace guisfits.HealthTrack.Domain.Services
{
    public class PressaoArterialService : EntityService<PressaoArterial>, IPressaoArterialService
    {
        private IPressaoArterialRepository _repository;

        public PressaoArterialService(IPressaoArterialRepository repository) 
            : base(repository)
        {
            _repository = repository;
        }

        public IEnumerable<PressaoArterial> ObterTodosPorUsuario(Guid id)
        {
            return _repository.ObterTodosPorUsuario(id);
        }
    }
}
