using DomainValidation.Interfaces.Specification;

namespace guisfits.HealthTrack.Domain.Specification.PressaoArterial
{
    public class PressaoDeveTerValoresPossiveisSpecification : ISpecification<Models.PressaoArterial>
    {
        public bool IsSatisfiedBy(Models.PressaoArterial entity)
        {
            return entity.Diastolica < entity.Sistolica;
        }
    }
}
