using System.Collections.Generic;
using System.Linq;
using HealthTrack.Data.Context;
using HealthTrack.Domain.Interfaces.Repository;
using HealthTrack.Domain.Models;

namespace HealthTrack.Data.Repository
{
    public class PressaoArterialRepository : Repository<PressaoArterial>, IPressaoArterialRepository
    {
        public PressaoArterialRepository(HealthTrackContext context) 
            : base(context)
        {
        }

        public IEnumerable<PressaoArterial> ObterPorUsuario(string id)
        {
            return context.PressoesArteriais
                .Where(x => x.UsuarioId == id)
                .OrderByDescending(c => c.DataHora)
                .ToList();
        }
    }
}
