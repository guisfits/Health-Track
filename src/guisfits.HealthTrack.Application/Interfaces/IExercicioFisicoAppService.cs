using System;
using System.Collections.Generic;
using guisfits.HealthTrack.Application.ViewModels;

namespace guisfits.HealthTrack.Application.Interfaces
{
    public interface IExercicioFisicoAppService : IEntityAppService<ExercicioFisicoViewModel>
    {
        IEnumerable<ExercicioFisicoViewModel> ObterTodosPorUsuario(Guid id);
    }
}