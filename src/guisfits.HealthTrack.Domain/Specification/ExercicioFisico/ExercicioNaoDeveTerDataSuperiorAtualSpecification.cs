using DomainValidation.Interfaces.Specification;
using guisfits.HealthTrack.Domain.ValueObjects;

namespace guisfits.HealthTrack.Domain.Specification.ExercicioFisico
{
    public class ExercicioNaoDeveTerDataSuperiorAtualSpecification : ISpecification<Models.ExercicioFisico>
    {
        public bool IsSatisfiedBy(Models.ExercicioFisico entity)
        {
            return DataHora.Validar(entity.DataHora);
        }
    }
}
