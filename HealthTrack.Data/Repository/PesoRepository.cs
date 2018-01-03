using System.Collections.Generic;
using System.Linq;
using HealthTrack.Data.Context;
using HealthTrack.Domain.Interfaces.Repository;
using HealthTrack.Domain.Models;

namespace HealthTrack.Data.Repository
{
    public class PesoRepository : Repository<Peso>, IPesoRepository
    {
        public PesoRepository(HealthTrackContext context) 
            : base(context)
        {
        }

        public IEnumerable<Peso> ObterPorUsuario(string id)
        {
            return context.Pesos
                .Where(x => x.UsuarioId == id)
                .OrderByDescending(c => c.DataHora)
                .ToList();
        }
    }
}
