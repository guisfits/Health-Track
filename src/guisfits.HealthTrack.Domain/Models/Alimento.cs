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
        public Guid UsuarioId { get; set; }

        //Para o Lazy loading do EntityFramework
        public virtual Usuario Usuario { get; set; }

        public Alimento(TipoAlimento tipo, double calorias, DateTime dataHora, string descricao = "")
        
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