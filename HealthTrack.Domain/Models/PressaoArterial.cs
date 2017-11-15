using System;
using FluentValidation.Results;
using HealthTrack.Domain.Validation;

namespace HealthTrack.Domain.Models
{
    public class PressaoArterial
    {
        public string Id { get; set; }
        public DateTime DataHora { get; set; }
        public float Sistolica { get; set; } 
        public float Diastolica { get; set; }
        public string Status { get; private set; }
        
        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public PressaoArterialValidation Validation { get; private set; }

        public PressaoArterial(float sistolica, float diastolica, DateTime dataHora)
        {
            DataHora = dataHora;
            Sistolica = sistolica;
            Diastolica = diastolica;
            Id = Guid.NewGuid().ToString();
            Status = ObterStatus();
            Validation = new PressaoArterialValidation();
        }

        public PressaoArterial()
        {
            Id = Guid.NewGuid().ToString();
            Validation = new PressaoArterialValidation();
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

        public ValidationResult Validar()
        {
            return Validation.Validate(this);
        }
    }
}