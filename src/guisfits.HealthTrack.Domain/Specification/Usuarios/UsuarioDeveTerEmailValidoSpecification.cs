using DomainValidation.Interfaces.Specification;
using guisfits.HealthTrack.Domain.Models;

namespace guisfits.HealthTrack.Domain.Specification.Usuarios
{
    public class UsuarioDeveTerEmailValidoSpecification : ISpecification<Usuario>
    {
        public bool IsSatisfiedBy(Usuario entity)
        {
            return true;
        }
    }
}
