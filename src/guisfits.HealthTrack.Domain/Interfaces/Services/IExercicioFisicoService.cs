using System;
using System.Collections.Generic;
using guisfits.HealthTrack.Domain.Models;

namespace guisfits.HealthTrack.Domain.Interfaces.Services
{
    public interface IExercicioFisicoService : IEntityService<ExercicioFisico>
    {
        IEnumerable<ExercicioFisico> ObterTodosPorUsuario(Guid id);
    }
}
