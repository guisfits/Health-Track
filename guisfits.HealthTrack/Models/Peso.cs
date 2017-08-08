using System;

namespace guisfits.HealthTrack.Models
{
    //Struct pois Peso se comportará como ValueType
    public struct Peso : IEquatable<Peso>
    {
        public DateTime DataHora { get; set; }

        private double _valorKg;
        public double ValorKg
        {
            get { return _valorKg; }
            set
            {   if (value > 0)
                    _valorKg = value;
                else
                    throw new Exception();
            }
        }

        public Peso(double PesoKg, DateTime DataHora)
        {
            if (PesoKg > 0)
                this._valorKg = PesoKg;
            else
                throw new Exception();

            this.DataHora = DataHora;
        }

        public Peso(double PesoKg)
        {
            if (PesoKg > 0)
                this._valorKg = PesoKg;
            else
                throw new Exception();

            this.DataHora = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{this._valorKg} kg";
        }

        #region Implementação de operadores/metodos de Igualdade

        //Implementação real que deverá ser usada nos outros metodos de igualdade
        public bool Equals(Peso other)
        {
            return (this._valorKg == other.ValorKg) && (this.DataHora == other.DataHora);
        }

        public override bool Equals(object obj)
        {
            return this.Equals((Peso)obj);
        }

        public override int GetHashCode()
        {
            return this._valorKg.GetHashCode() ^ this.DataHora.GetHashCode();
        }

        public static bool operator ==(Peso p1, Peso p2)
        {
            return p1.Equals(p2);
        }

        public static bool operator !=(Peso p1, Peso p2)
        {
            return !(p1.Equals(p2));
        }

        #endregion
    }
}