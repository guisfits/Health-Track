using DomainValidation.Validation;
using guisfits.HealthTrack.Domain.Models;
using guisfits.HealthTrack.Domain.Specification.Usuarios;

namespace guisfits.HealthTrack.Domain.Validation.Usuarios
{
    public class UsuarioEstaConsistenteValidation : Validator<Usuario>
    {
        public UsuarioEstaConsistenteValidation()
        {
            var EmailSpecification = new UsuarioDeveTerEmailValidoSpecification();
            this.Add("EmailSpecification", new Rule<Usuario>(EmailSpecification, "O E-mail está em formato incorreto"));
        }
    }
}
