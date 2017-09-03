using System;
using System.Collections.Generic;
using guisfits.HealthTrack.Application.ViewModels;

namespace guisfits.HealthTrack.Application.Interfaces
{
    public interface IAlimentoAppService : IEntityAppService<AlimentoViewModel>
    {
        IEnumerable<AlimentoViewModel> ObterTodosPorUsuario(Guid id);
    }
}