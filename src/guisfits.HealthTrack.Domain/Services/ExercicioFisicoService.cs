using guisfits.HealthTrack.Domain.Interfaces.Repository;
using guisfits.HealthTrack.Domain.Interfaces.Services;
using guisfits.HealthTrack.Domain.Models;

namespace guisfits.HealthTrack.Domain.Services
{
    public class ExercicioFisicoService : EntityService<ExercicioFisico>, IExercicioFisicoService
    {
        public ExercicioFisicoService(IExercicioFisicoRepository repository) 
            : base(repository)
        {
        }
    }
}
