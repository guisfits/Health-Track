using System;
using FluentValidation.Results;
using HealthTrack.Domain.Validation;

namespace HealthTrack.Domain.Models
{
    public class Peso : BaseEntity
    {
        public float ValorPeso { get; set; }
        public DateTime DataHora { get; set; }

        public string UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        private readonly PesoValidation _validation;

        public Peso(float pesoKg)
        {
            ValorPeso= pesoKg;
            DataHora = DateTime.Now;
            Id = Guid.NewGuid().ToString();
            _validation = new PesoValidation();
        }

        protected Peso()
        {
            _validation = new PesoValidation();
        }

        public override ValidationResult Validar()
        {
            return _validation.Validate(this);
        }

        public override string ToString()
        {
            return $"{ValorPeso} kg";
        }
    }
}
