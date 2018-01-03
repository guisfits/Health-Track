using System.Collections.Generic;
using System.Linq;
using HealthTrack.Data.Context;
using HealthTrack.Domain.Interfaces.Repository;
using HealthTrack.Domain.Models;

namespace HealthTrack.Data.Repository
{
    public class ExercicioFisicoRepository : Repository<ExercicioFisico>, IExercicioFisicoRepository
    {
        public ExercicioFisicoRepository(HealthTrackContext context) 
            : base(context)
        {
        }

        public IEnumerable<ExercicioFisico> ObterPorUsuario(string id)
        {
            return context.ExerciciosFisicos
                .Where(x => x.UsuarioId == id)
                .OrderByDescending(c => c.DataHora)
                .ToList();
        }
    }
}
