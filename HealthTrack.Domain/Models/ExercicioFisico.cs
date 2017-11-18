using System;
using FluentValidation.Results;
using HealthTrack.Domain.Enums;
using HealthTrack.Domain.Validation;

namespace HealthTrack.Domain.Models
{
    public class ExercicioFisico : BaseEntity
    {
        public string Descricao { get; set; }
        public float Calorias { get; set; }
        public DateTime DataHora { get; set; }
        public ExercicioTipo Tipo { get; set; }

        public string UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        private readonly ExercicioFisicoValidation _validation;

        public ExercicioFisico()
        {
            _validation = new ExercicioFisicoValidation();
        }

        public override ValidationResult Validar()
        {
            return _validation.Validate(this);
        }
    }
}
