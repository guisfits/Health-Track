using DomainValidation.Interfaces.Specification;
using guisfits.HealthTrack.Domain.ValueObjects;

namespace guisfits.HealthTrack.Domain.Specification.Peso
{
    public class PesoNaoDeveTerDataSuperiorAtualSpecification : ISpecification<Models.Peso>
    {
        public bool IsSatisfiedBy(Models.Peso entity)
        {
            return DataHora.Validar(entity.DataHora);
        }
    }
}
