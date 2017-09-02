using System;
using guisfits.HealthTrack.Domain.Validation.Peso;

namespace guisfits.HealthTrack.Domain.Models
{
    public class Peso : Entity
    {
        public double PesoValue { get; set; }
        public DateTime DataHora { get; set; }
        public Guid UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        public Peso(double pesoValue, DateTime dataHora)
            : this(pesoValue)
        {
            this.DataHora = dataHora;
        }

        public Peso(double pesoKg)
        {
            this.PesoValue = pesoKg;
            this.DataHora = DateTime.Now;
        }

        public Peso()
        {

        }

        public override string ToString()
        {
            return $"{this.PesoValue} kg";
        }

        public override bool EhValido()
        {
            ValidationResult = new PesoEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}