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
            this.Add("AlturaSpecification", new Rule<Models.Usuario>(AlturaSpecification, "Altura deve ser entre 70 a 299 cm"));
            this.Add("PesoSpecification", new Rule<Models.Usuario>(PesoSpecification, "Peso deve ser menor que 300 kg"));
        }
    }
}
