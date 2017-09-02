using DomainValidation.Interfaces.Specification;
using guisfits.HealthTrack.Domain.ValueObjects;

namespace guisfits.HealthTrack.Domain.Specification.Usuario
{
    public class UsuarioDeveTerNomeValidoSpecification : ISpecification<Models.Usuario>
    {
        public bool IsSatisfiedBy(Models.Usuario entity)
        {
            return NomeSobrenome.Validar(entity.Nome) && NomeSobrenome.Validar(entity.Sobrenome);
        }
    }
}
