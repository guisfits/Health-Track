using System;
using guisfits.HealthTrack.Domain.Validation.ExercicioFisico;

namespace guisfits.HealthTrack.Domain.Models
{
    public enum TipoExercicio { Caminhada, Corrida, Pedalada, Musculacao }

    public class ExercicioFisico : Entity
    {
        public TipoExercicio Tipo { get; set; }
        public string Descricao { get; set; }
        public double Calorias { get; set; }
        public DateTime DataHora { get; set; }
        public Guid UsuarioId { get; set; }
        //Para o Lazy loading do EntityFramework
        public virtual Usuario Usuario { get; set; }

        public override bool EhValido()
        {
            ValidationResult = new ExercicioEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}