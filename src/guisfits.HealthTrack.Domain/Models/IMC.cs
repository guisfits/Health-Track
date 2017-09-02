namespace guisfits.HealthTrack.Domain.Models
{
    public class Imc
    {
        private readonly double _peso;
        private readonly double _altura;

        public string Status
        {
            get
            {
                if (Valor < 17)
                    return "Muito abaixo do peso";

                if(Valor <= 18.49) 
                    return "Abaixo do peso";

                if(Valor <= 24.99) 
                    return "Peso normal";

                if(Valor <= 29.99) 
                    return "Acima do peso";

                if(Valor <= 34.99) 
                    return "Obeso";

                if(Valor <= 39.99) 
                    return "Obesidade severa";

                return "Obesidade mórbida";
            }
        }

        public double Valor => _peso / (_altura * _altura);

        public Imc(double peso, double altura)
        {
            _peso = peso;
            _altura = altura;
        }
    }
}