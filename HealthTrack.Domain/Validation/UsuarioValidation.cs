using System.Text.RegularExpressions;
using FluentValidation;
using HealthTrack.Domain.Models;

namespace HealthTrack.Domain.Validation
{
    public class UsuarioValidation : AbstractValidator<Usuario>
    {
        public UsuarioValidation()
        {
            RuleFor(c => c.Altura)
                .InclusiveBetween(100, 300).WithMessage("Altura deve ser entre 100cm a 300cm");

            RuleFor(c => c.Nome)
                .Length(2, 32).WithMessage("Tamanho de caracteres inválidos")
                .Must(ValidarNome).WithMessage("Nome inválido");

            RuleFor(c => c.Sobrenome)
                .Length(2, 120).WithMessage("Tamanho de caracteres inválidos")
                .Must(ValidarNome).WithMessage("Sobrenome inválido");
        }

        private static bool ValidarNome(string nome)
        {
            var ce = "áàâãóòôõéèêúùíìç";
            var CE = ce.ToUpper();
            var cE = ce + CE;

            return Regex.IsMatch(nome, $"^[a-zA-Z{cE}]+(([',. -][a-zA-Z{cE} ])?[a-zA-Z{cE}]*)*$", RegexOptions.IgnorePatternWhitespace);
        }
    }
}
