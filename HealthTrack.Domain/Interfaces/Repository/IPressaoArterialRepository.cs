using System.Collections.Generic;
using HealthTrack.Domain.Models;

namespace HealthTrack.Domain.Interfaces.Repository
{
    public interface IPressaoArterialRepository : IRepository<PressaoArterial>
    {
        IEnumerable<PressaoArterial> ObterPorUsuario(string id);
    }
}
