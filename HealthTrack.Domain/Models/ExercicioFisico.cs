using System;
using FluentValidation.Results;
using HealthTrack.Domain.Enums;
using HealthTrack.Domain.Validation;

namespace HealthTrack.Domain.Models
{
    public class ExercicioFisico
    {
        public string Id { get; set; }
        public string Descricao { get; set; }
        public float Calorias { get; set; }
        public DateTime DataHora { get; set; }
        public ExercicioTipo Tipo { get; set; }

        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public ExercicioFisicoValidation Validation { get; private set; }

        public ExercicioFisico()
        {
            Id = Guid.NewGuid().ToString();
            Validation = new ExercicioFisicoValidation();
        }

        public ValidationResult Validar()
        {
            return Validation.Validate(this);
        }
    }
}
