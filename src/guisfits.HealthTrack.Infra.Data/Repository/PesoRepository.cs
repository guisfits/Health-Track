using guisfits.HealthTrack.Domain.Interfaces.Repository;
using guisfits.HealthTrack.Domain.Models;
using guisfits.HealthTrack.Infra.Data.Context;

namespace guisfits.HealthTrack.Infra.Data.Repository
{
    public class PesoRepository : Repository<Peso>, IPesoRepository
    {
        public PesoRepository(HealthTrackContext context) : base(context)
        {
        }
    }
}
