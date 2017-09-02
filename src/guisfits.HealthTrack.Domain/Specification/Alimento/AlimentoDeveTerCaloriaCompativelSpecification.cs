using DomainValidation.Interfaces.Specification;
using guisfits.HealthTrack.Domain.ValueObjects;

namespace guisfits.HealthTrack.Domain.Specification.Alimento
{
    public class AlimentoDeveTerCaloriaCompativelSpecification : ISpecification<Models.Alimento>
    {
        public bool IsSatisfiedBy(Models.Alimento entity)
        {
            return Calorias.Validar(entity.Calorias);
        }
    }
}
