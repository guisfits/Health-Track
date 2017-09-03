using System;
using System.Collections.Generic;
using guisfits.HealthTrack.Application.ViewModels;

namespace guisfits.HealthTrack.Application.Interfaces
{
    public interface IPressaoArterialAppService : IEntityAppService<PressaoArterialViewModel>
    {
        IEnumerable<PressaoArterialViewModel> ObterTodosPorUsuario(Guid id);
    }
}