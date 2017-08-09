using System;

namespace guisfits.HealthTrack.Domain.Models
{
    public class IMC
    {
        private double _peso;
        private double _altura;

        public string Status
        {
            get
            {
                if (Valor < 17)
                    return "Muito abaixo do peso";

                else if(Valor <= 18.49) 
                    return "Abaixo do peso";

                else if(Valor <= 24.99) 
                    return "Peso normal";

                else if(Valor <= 29.99) 
                    return "Acima do peso";

                else if(Valor <= 34.99) 
                    return "Obeso";

                else if(Valor <= 39.99) 
                    return "Obesidade severa";

                else
                    return "Obesidade mórbida";
            }
        }

        public double Valor
        {
            get
            {
                return _peso / (_altura * _altura);
            }
        }

        public void setValor(double Peso, double Altura)
        {
            _peso = Peso;
            _altura = Altura;
        }

        public DateTime DataHora { get; set; }

        public IMC(double Peso, double Altura)
        {
            _peso = Peso;
            _altura = Altura;
            DataHora = DateTime.Now;
        }
    }
}