using System.Collections.Generic;
using HealthTrack.Domain.Models;

namespace HealthTrack.Domain.Interfaces.Repository
{
    public interface IPesoRepository : IRepository<Peso>
    {
        IEnumerable<Peso> ObterPorUsuario(string id);
    }
}
