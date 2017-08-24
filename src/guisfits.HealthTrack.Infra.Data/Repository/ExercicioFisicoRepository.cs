using guisfits.HealthTrack.Domain.Interfaces.Repository;
using guisfits.HealthTrack.Domain.Models;
using guisfits.HealthTrack.Infra.Data.Context;

namespace guisfits.HealthTrack.Infra.Data.Repository
{
    public class ExercicioFisicoRepository : Repository<ExercicioFisico>, IExercicioFisicoRepository
    {
        public ExercicioFisicoRepository(HealthTrackContext context) : base(context)
        {
        }
    }
}
