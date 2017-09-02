namespace guisfits.HealthTrack.Domain.ValueObjects
{
    public class Diastolica
    {
        public static bool Validar(double diastolica)
        {
            return diastolica > 0 && diastolica < 300;
        }
    }
}
