using System;
using System.Collections.Generic;
using guisfits.HealthTrack.Domain.Models;

namespace guisfits.HealthTrack.Domain.Interfaces.Repository
{
    public interface IAlimentoRepository : IRepository<Alimento>
    {
        IEnumerable<Alimento> ObterTodosPorUsuario(Guid id);
    }
}
