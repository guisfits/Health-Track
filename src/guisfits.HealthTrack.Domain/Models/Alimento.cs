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

        public override bool EhValido()
        {
            //Esperando pelas classes de validação
            return true;
        }
    }
}