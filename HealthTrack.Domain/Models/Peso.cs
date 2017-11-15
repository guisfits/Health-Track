using System;
using FluentValidation.Results;
using HealthTrack.Domain.Validation;

namespace HealthTrack.Domain.Models
{
    public class Peso
    {
        public string Id { get; set; }
        public float ValorPeso { get; set; }
        public DateTime DataHora { get; set; }

        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public PesoValidation Validation { get; private set;  }

        public Peso(float pesoKg)
        {
            ValorPeso= pesoKg;
            DataHora = DateTime.Now;
            Id = Guid.NewGuid().ToString();
            Validation = new PesoValidation();
        }

        public Peso()
        {
            Id = Guid.NewGuid().ToString();
            Validation = new PesoValidation();
        }

        public ValidationResult Validar()
        {
            return Validation.Validate(this);
        }

        public override string ToString()
        {
            return $"{ValorPeso} kg";
        }
    }
}
