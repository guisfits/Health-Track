using System;

namespace guisfits.HealthTrack.Domain.Models
{
    public enum TipoExercicio { Caminhada, Corrida, Pedalada, Musculacao }

    public class ExercicioFisico
    {
        public TipoExercicio Tipo { get; set; }
        public string Descricao { get; set; }
        public double Calorias { get; set; }
        public DateTime DataHora { get; set; }

        public ExercicioFisico(TipoExercicio tipo, string descricao, double calorias, DateTime dataHora)
        {
            this.Tipo = tipo;
            this.Descricao = descricao;
            this.Calorias = calorias;
            this.DataHora = dataHora;
        }
    }
}