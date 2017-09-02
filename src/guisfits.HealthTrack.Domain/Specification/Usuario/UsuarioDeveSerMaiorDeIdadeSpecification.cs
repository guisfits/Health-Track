using DomainValidation.Interfaces.Specification;
using guisfits.HealthTrack.Domain.ValueObjects;

namespace guisfits.HealthTrack.Domain.Specification.Usuario
{
    public class UsuarioDeveSerMaiorDeIdadeSpecification : ISpecification<Models.Usuario>
    {
        public bool IsSatisfiedBy(Models.Usuario entity)
        {
            return Nascimento.Validar(entity.Nascimento);
        }
    }
}
