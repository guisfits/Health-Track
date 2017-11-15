using System;

namespace HealthTrack.Domain.Models
{
    public class Imc
    {
        private readonly float _peso;
        private readonly float _altura;

        public string Status
        {
            get
            {
                if (Valor < 17)
                    return "Muito abaixo do peso";

                else if (Valor <= 18.49)
                    return "Abaixo do peso";

                else if (Valor <= 24.99)
                    return "Peso normal";

                else if (Valor <= 29.99)
                    return "Acima do peso";

                else if (Valor <= 34.99)
                    return "Obeso";

                else if (Valor < 40)
                    return "Obesidade severa";
                else if (Valor > 40)
                    return "Obesidade mórbida";
                else
                    return "Não calculável";
            }
        }

        private float _valor;
        public float Valor
        {
            get
            {
                _valor = _peso / (_altura * _altura);
                _valor = (float)Math.Round(_valor, 2);
                return _valor;
            }
            set => _valor = value;
        }

        public Imc(float peso = 0, float altura = 0)
        {
            if (peso <= 0 || altura <= 0) return;

            _peso = peso;
            _altura = altura / 100;
        }

        public Imc()
        {
            
        }
    }
}