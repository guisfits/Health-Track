using System.Collections.Generic;
using System.Linq;
using HealthTrack.Data.Context;
using HealthTrack.Domain.Interfaces.Repository;
using HealthTrack.Domain.Models;

namespace HealthTrack.Data.Repository
{
    public class AlimentoRepository : Repository<Alimento>, IAlimentoRepository
    {
        public AlimentoRepository(HealthTrackContext context) 
            : base(context)
        {
        }

        public IEnumerable<Alimento> ObterPorUsuario(string usuarioId)
        {
            return context.Alimentos
                    .Where(x => x.UsuarioId == usuarioId)
                    .OrderByDescending(c => c.DataHora)
                    .ToList();
        }
    }
}
