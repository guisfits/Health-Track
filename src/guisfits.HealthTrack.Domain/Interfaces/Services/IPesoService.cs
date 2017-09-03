using System;
using System.Collections.Generic;
using guisfits.HealthTrack.Domain.Models;

namespace guisfits.HealthTrack.Domain.Interfaces.Services
{
    public interface IPesoService : IEntityService<Peso>
    {
        IEnumerable<Peso> ObterTodosPorUsuario(Guid id);
    }
}
