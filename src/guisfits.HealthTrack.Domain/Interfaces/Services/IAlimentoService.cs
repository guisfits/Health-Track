using System;
using System.Collections.Generic;
using guisfits.HealthTrack.Domain.Models;

namespace guisfits.HealthTrack.Domain.Interfaces.Services
{
    public interface IAlimentoService : IEntityService<Alimento>
    {
        IEnumerable<Alimento> ObterTodosPorUsuario(Guid id);
    }
}