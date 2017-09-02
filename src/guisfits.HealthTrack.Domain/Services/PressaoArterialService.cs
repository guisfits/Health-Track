using guisfits.HealthTrack.Domain.Interfaces.Repository;
using guisfits.HealthTrack.Domain.Interfaces.Services;
using guisfits.HealthTrack.Domain.Models;

namespace guisfits.HealthTrack.Domain.Services
{
    public class PressaoArterialService : EntityService<PressaoArterial>, IPressaoArterialService
    {
        public PressaoArterialService(IPressaoArterialRepository repository) 
            : base(repository)
        {
        }
    }
}
