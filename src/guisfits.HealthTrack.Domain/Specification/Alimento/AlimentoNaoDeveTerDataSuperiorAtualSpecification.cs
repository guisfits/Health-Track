using DomainValidation.Interfaces.Specification;
using guisfits.HealthTrack.Domain.ValueObjects;

namespace guisfits.HealthTrack.Domain.Specification.Alimento
{
    public class AlimentoNaoDeveTerDataSuperiorAtualSpecification : ISpecification<Models.Alimento>
    {
        public bool IsSatisfiedBy(Models.Alimento entity)
        {
            return DataHora.Validar(entity.DataHora);
        }
    }
}
