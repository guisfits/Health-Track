using guisfits.HealthTrack.Domain.Interfaces.Repository;
using guisfits.HealthTrack.Domain.Models;
using guisfits.HealthTrack.Infra.Data.Context;

namespace guisfits.HealthTrack.Infra.Data.Repository
{
    public class AlimentoRepository : Repository<Alimento>, IAlimentoRepository
    {
        public AlimentoRepository(HealthTrackContext context) : base(context)
        {
        }
    }
}
