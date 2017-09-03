using System;
using System.Collections.Generic;
using guisfits.HealthTrack.Domain.Models;

namespace guisfits.HealthTrack.Domain.Interfaces.Repository
{
    public interface IPressaoArterialRepository : IRepository<PressaoArterial>
    {
        IEnumerable<PressaoArterial> ObterTodosPorUsuario(Guid id);

    }
}
