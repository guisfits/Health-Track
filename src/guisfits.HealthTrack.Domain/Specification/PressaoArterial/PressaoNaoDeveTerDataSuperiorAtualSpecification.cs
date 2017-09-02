using DomainValidation.Interfaces.Specification;
using guisfits.HealthTrack.Domain.ValueObjects;

namespace guisfits.HealthTrack.Domain.Specification.PressaoArterial
{
    public class PressaoNaoDeveTerDataSuperiorAtualSpecification : ISpecification<Models.PressaoArterial>
    {
        public bool IsSatisfiedBy(Models.PressaoArterial entity)
        {
            return DataHora.Validar(entity.DataHora);
        }
    }
}
