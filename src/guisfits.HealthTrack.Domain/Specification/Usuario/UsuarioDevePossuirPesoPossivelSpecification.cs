using DomainValidation.Interfaces.Specification;
using guisfits.HealthTrack.Domain.ValueObjects;

namespace guisfits.HealthTrack.Domain.Specification.Usuario
{
    public class UsuarioDevePossuirPesoPossivelSpecification : ISpecification<Models.Usuario>
    {
        public bool IsSatisfiedBy(Models.Usuario entity)
        {
            return Peso.Validar(entity.PesoAtual);
        }
    }
}
