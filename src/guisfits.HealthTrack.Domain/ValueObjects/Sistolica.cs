namespace guisfits.HealthTrack.Domain.ValueObjects
{
    public class Sistolica
    {
        public static bool Validar(double sistolica)
        {
            return sistolica > 0 && sistolica < 300;
        }
    }
}
