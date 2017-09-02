using DomainValidation.Validation;
using guisfits.HealthTrack.Domain.Specification.Usuario;

namespace guisfits.HealthTrack.Domain.Validation.Usuario
{
    public class UsuarioEstaConsistenteValidation : Validator<Models.Usuario>
    {
        public UsuarioEstaConsistenteValidation()
        {
            var NascimentoSpecification = new UsuarioDeveSerMaiorDeIdadeSpecification();
            var AlturaSpecification = new UsuarioDevePossuirAlturaPossivelSpecification();
            var PesoSpecification = new UsuarioDevePossuirPesoPossivelSpecification();
            this.Add("NascimentoSpecification", new Rule<Models.Usuario>(NascimentoSpecification, "O usuário deve ser maior de idade"));
            this.Add("AlturaSpecification", new Rule<Models.Usuario>(AlturaSpecification, "Altura deve ter um valor possível"));
            this.Add("PesoSpecification", new Rule<Models.Usuario>(PesoSpecification, "Peso deve ter um valor possível"));
        }
    }
}
