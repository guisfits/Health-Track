using System.Collections.Generic;
using HealthTrack.Domain.Models;

namespace HealthTrack.Domain.Interfaces.Repository
{
    public interface IAlimentoRepository : IRepository<Alimento>
    {
        IEnumerable<Alimento> ObterPorUsuario(string id);
    }
}
