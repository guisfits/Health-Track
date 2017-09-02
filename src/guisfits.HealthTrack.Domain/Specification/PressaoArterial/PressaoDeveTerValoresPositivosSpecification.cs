using DomainValidation.Interfaces.Specification;
using guisfits.HealthTrack.Domain.ValueObjects;

namespace guisfits.HealthTrack.Domain.Specification.PressaoArterial
{
    public class PressaoDeveTerValoresPositivosSpecification : ISpecification<Models.PressaoArterial>
    {
        public bool IsSatisfiedBy(Models.PressaoArterial entity)
        {
            return Diastolica.Validar(entity.Diastolica) && Sistolica.Validar(entity.Sistolica);
        }
    }
}
