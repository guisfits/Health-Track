using guisfits.HealthTrack.Domain.Helpers;
using guisfits.HealthTrack.Domain.Validation.ExercicioFisico;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace guisfits.HealthTrack.Domain.Models
{
    public enum TipoExercicio
    {
        Caminhada,
        Corrida,
        Pedalada,
        [Display(Name = "Musculação")]
        Musculacao
    }

    public class ExercicioFisico : Entity
    {
        public string Descricao { get; set; }
        public double Calorias { get; set; }
        public DateTime DataHora { get; set; }
        public Guid UsuarioId { get; set; }
        //Para o Lazy loading do EntityFramework
        public virtual Usuario Usuario { get; set; }

        public TipoExercicio Tipo { get; set; }
        [Column("Tipo")]
        public string TipoExercicioString
        {
            get => Tipo.ToString();
            set => Tipo = value.ParceToEnum<TipoExercicio>();
        }

        public override bool EhValido()
        {
            ValidationResult = new ExercicioEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}