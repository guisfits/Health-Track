using DomainValidation.Validation;
using guisfits.HealthTrack.Domain.Models;
using guisfits.HealthTrack.Domain.Specification.Usuario;

namespace guisfits.HealthTrack.Domain.Validation.Usuario
{
    public class UsuarioEstaConsistenteValidation : Validator<Models.Usuario>
    {
        public UsuarioEstaConsistenteValidation()
        {
            var EmailSpecification = new UsuarioDeveTerEmailValidoSpecification();
            this.Add("EmailSpecification", new Rule<Models.Usuario>(EmailSpecification, "O E-mail está em formato incorreto"));
        }
    }
}
