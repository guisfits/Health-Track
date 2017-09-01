using System;

namespace guisfits.HealthTrack.Domain.Models
{
    public class Peso : Entity
    {
        public DateTime DataHora { get; set; }
        public Guid UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        private double _valorKg;
        public double ValorKg
        {
            get => _valorKg;
            set
            {   if (value > 0)
                    _valorKg = value;
                else
                    throw new Exception();
            }
        }

        public Peso(double PesoKg, DateTime DataHora)
            : this(PesoKg)
        {
            this.DataHora = DataHora;
        }

        public Peso(double pesoKg)
        {
            if (pesoKg > 0)
                this._valorKg = pesoKg;
            else
                throw new Exception();

            this.DataHora = DateTime.Now;
        }

        public Peso()
        {

        }

        public override string ToString()
        {
            return $"{this._valorKg} kg";
        }

        public override bool EhValido()
        {
            //Esperando pelas classes de validação
            return true;
        }
    }
}