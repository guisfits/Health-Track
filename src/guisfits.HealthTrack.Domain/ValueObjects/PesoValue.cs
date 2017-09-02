namespace guisfits.HealthTrack.Domain.ValueObjects
{
    public class PesoValue
    {
        public static bool Validar(double peso)
        {
            return peso > 0 && peso < 300;
        }
    }
}
