namespace guisfits.HealthTrack.Domain.Services
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

        public IMC(double Peso, double Altura)
        {
            _peso = Peso;
            _altura = Altura;
        }
    }
}