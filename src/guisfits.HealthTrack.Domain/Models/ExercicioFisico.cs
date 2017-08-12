using System;

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

        public ExercicioFisico(TipoExercicio tipo, string descricao, double calorias, DateTime dataHora)
        {
            this.Tipo = tipo;
            this.Descricao = descricao;
            this.Calorias = calorias;
            this.DataHora = dataHora;
        }

        protected override bool EhValido()
        {
            //tem que validar!!!
            return true;
        }
    }
}