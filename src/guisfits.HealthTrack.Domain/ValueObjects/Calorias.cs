namespace guisfits.HealthTrack.Domain.ValueObjects
{
    public class Calorias
    {
        public static bool Validar(double calorias)
        {
            return calorias > 0 && calorias < 1000;
        }
    }
}
