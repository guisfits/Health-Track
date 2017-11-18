using System;
using FluentValidation.Results;
using HealthTrack.Domain.Enums;
using HealthTrack.Domain.Validation;

namespace HealthTrack.Domain.Models
{
    public class Alimento : BaseEntity
    {
        public string Descricao { get; set; }
        public float Calorias { get; set; }
        public DateTime DataHora { get; set; }
        public AlimentoTipo Tipo { get; set; }

        public string UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        private readonly AlimentoValidation _validation;

        public Alimento()
        {
            _validation = new AlimentoValidation();
        }

        public override ValidationResult Validar()
        {
            return _validation.Validate(this);
        }
    }
}
