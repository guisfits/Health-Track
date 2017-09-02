using DomainValidation.Interfaces.Specification;

namespace guisfits.HealthTrack.Domain.Specification.Usuario
{
    public class UsuarioDeveTerUmPesoSpecification : ISpecification<Models.Usuario>
    {
        public bool IsSatisfiedBy(Models.Usuario entity)
        {
            return entity.Pesos.Count > 0;
        }
    }
}
