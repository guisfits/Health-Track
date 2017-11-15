using System;
using FluentValidation.Results;
using HealthTrack.Domain.Enums;
using HealthTrack.Domain.Validation;

namespace HealthTrack.Domain.Models
{
    public class Alimento
    {
        public string Id { get; set; }
        public string Descricao { get; set; }
        public float Calorias { get; set; }
        public DateTime DataHora { get; set; }
        public AlimentoTipo Tipo { get; set; }

        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public AlimentoValidation Validation { get; private set; }

        public Alimento()
        {
            Validation = new AlimentoValidation();
        }

        public ValidationResult Validar()
        {
            return Validation.Validate(this);
        }
    }
}
