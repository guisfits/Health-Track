using guisfits.HealthTrack.Domain.Interfaces.Repository;
using guisfits.HealthTrack.Domain.Interfaces.Services;
using guisfits.HealthTrack.Domain.Models;

namespace guisfits.HealthTrack.Domain.Services
{
    public class PesoService : EntityService<Peso>, IPesoService
    {
        public PesoService(IPesoRepository repository) 
            : base(repository)
        {
        }
    }
}
