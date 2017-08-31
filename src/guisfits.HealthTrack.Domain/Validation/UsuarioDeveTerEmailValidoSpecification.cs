using DomainValidation.Interfaces.Specification;
using guisfits.HealthTrack.Domain.Models;
using guisfits.HealthTrack.Domain.ValueObjects;

namespace guisfits.HealthTrack.Domain.Specification.Usuario
{
    public class UsuarioDeveTerEmailValidoSpecification : ISpecification<Models.Usuario>
    {
        public bool IsSatisfiedBy(Models.Usuario entity)
        {
            //return Email.Validar(entity.Email);
            return true;
        }
    }
}
