using DomainValidation.Interfaces.Specification;
using guisfits.HealthTrack.Domain.Models;
using guisfits.HealthTrack.Domain.ValueObjects;

namespace guisfits.HealthTrack.Domain.Specification.Usuarios
{
    public class UsuarioDeveTerEmailValidoSpecification : ISpecification<Usuario>
    {
        public bool IsSatisfiedBy(Usuario entity)
        {
            return Email.Validar(entity.Email);
        }
    }
}
