using System;
using System.Collections.Generic;
using guisfits.HealthTrack.Application.ViewModels;

namespace guisfits.HealthTrack.Application.Interfaces
{
    public interface IPesoAppService : IEntityAppService<PesoViewModel>
    {
        IEnumerable<PesoViewModel> ObterTodosPorUsuario(Guid id);
    }
}