using System;
using FluentValidation;
using HealthTrack.Domain.Models;

namespace HealthTrack.Domain.Validation
{
    public class PesoValidation : AbstractValidator<Peso>
    {
        public PesoValidation()
        {
            RuleFor(c => c.ValorPeso)
                .InclusiveBetween(20, 300).WithMessage("Peso deve ser entre 20 a 300 kgs");

            RuleFor(c => c.DataHora)
                .LessThan(DateTime.Now).WithMessage("Data deve ser menor que a data atual")
                .GreaterThan(DateTime.Now.AddYears(-1)).WithMessage($"Ano deve ser maior que {DateTime.Now.AddYears(-1).Year}");
        }
    }
}
