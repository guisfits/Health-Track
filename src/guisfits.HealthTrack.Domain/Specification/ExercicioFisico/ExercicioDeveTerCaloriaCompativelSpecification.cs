using DomainValidation.Interfaces.Specification;
using guisfits.HealthTrack.Domain.ValueObjects;

namespace guisfits.HealthTrack.Domain.Specification.ExercicioFisico
{
    public class ExercucioDeveTerCaloriaCompativelSpecification : ISpecification<Models.ExercicioFisico>
    {
        public bool IsSatisfiedBy(Models.ExercicioFisico entity)
        {
            return Calorias.Validar(entity.Calorias);
        }
    }
}
