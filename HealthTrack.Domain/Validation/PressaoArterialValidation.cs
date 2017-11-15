using System;
using FluentValidation;
using HealthTrack.Domain.Models;

namespace HealthTrack.Domain.Validation
{
    public class PressaoArterialValidation : AbstractValidator<PressaoArterial>
    {
        public PressaoArterialValidation()
        {
            RuleFor(c => c.Diastolica)
                .LessThan(c => c.Sistolica).WithMessage("Diastolica deve ser menor que Sistolica");

            RuleFor(c => c.Sistolica)
                .GreaterThan(c => c.Diastolica).WithMessage("Sistolica deve ser maior que Diastolica");

            RuleFor(c => c.Status)
                .NotEqual("Sem identificação").WithMessage("Valores de Sistolica e Diastolica inválidos");

            RuleFor(c => c.DataHora)
                .LessThan(DateTime.Now).WithMessage("Data deve ser menor que a data atual")
                .GreaterThan(DateTime.Now.AddYears(-1)).WithMessage($"Ano deve ser maior que {DateTime.Now.AddYears(-1).Year}");
        }
    }
}
