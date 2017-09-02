using guisfits.HealthTrack.Domain.Interfaces.Repository;
using guisfits.HealthTrack.Domain.Interfaces.Services;
using guisfits.HealthTrack.Domain.Models;

namespace guisfits.HealthTrack.Domain.Services
{
    public class AlimentoService : EntityService<Alimento>, IAlimentoService
    {
        public AlimentoService(IAlimentoRepository repository) 
            : base(repository)
        {
        }
    }
}
