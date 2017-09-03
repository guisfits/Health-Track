using System;
using System.Collections.Generic;
using guisfits.HealthTrack.Domain.Models;

namespace guisfits.HealthTrack.Domain.Interfaces.Repository
{
    public interface IPesoRepository : IRepository<Peso>
    {
        IEnumerable<Peso> ObterTodosPorUsuario(Guid id);

    }
}
