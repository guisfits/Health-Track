using System;

namespace guisfits.HealthTrack.Domain.Models
{
    public enum TipoAlimento { CafeDaManha, Almoco, Jantar, Lanche, Fruta }

    public class Alimento : Entity
    {
        public TipoAlimento Tipo { get; set; }
        public string Descricao { get; set; }
        public double Calorias { get; set; }
        public DateTime DataHora { get; set; }

        public Alimento(TipoAlimento tipo, string descricao, double calorias, DateTime dataHora)
        
        {
            this.Tipo = tipo;
            this.Descricao = descricao;
            this.Calorias = calorias;
            this.DataHora = dataHora;
        }
    }
}