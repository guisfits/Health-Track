using System;
using FluentValidation.Results;
using HealthTrack.Domain.Validation;

namespace HealthTrack.Domain.Models
{
    public class PressaoArterial : BaseEntity
    {
        public DateTime DataHora { get; set; }
        public float Sistolica { get; set; } 
        public float Diastolica { get; set; }
        public string Status { get; private set; }
        
        public string UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        private readonly PressaoArterialValidation _validation;

        public PressaoArterial(float sistolica, float diastolica, DateTime dataHora)
        {
            DataHora = dataHora;
            Sistolica = sistolica;
            Diastolica = diastolica;
            Id = Guid.NewGuid().ToString();
            Status = ObterStatus();
            _validation = new PressaoArterialValidation();
        }

        protected PressaoArterial()
        {
            _validation = new PressaoArterialValidation();
        }

        public string ObterStatus()
        {
            if (Sistolica < 100 && Diastolica < 60)
            {
                Status = "Hipotensão";
                return Status;
            }
            if (Sistolica < 140 && Diastolica < 90)
            {
                Status = "Valores normais";
                return Status;
            }
            if (Sistolica < 160 && Diastolica < 100)
            {
                Status = "Hipertensão limite";
                return Status;
            }
            if (Sistolica < 180 && Diastolica < 100)
            {
                Status = "Hipertensão moderada";
                return Status;
            }
            if (Sistolica >= 180 && Diastolica > 110)
            {
                Status = "Hipertensão grave";
                return Status;
            }
            if (Sistolica > 140 && Diastolica < 90)
            {
                Status = "Valores normais";
                return Status;
            }
            else
            {
                Status = "Sem identificação";
                return Status;
            }
        }

        public override ValidationResult Validar()
        {
            return _validation.Validate(this);
        }
    }
}