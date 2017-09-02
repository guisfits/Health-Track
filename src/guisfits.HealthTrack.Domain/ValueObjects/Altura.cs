namespace guisfits.HealthTrack.Domain.ValueObjects
{
    public class Altura
    {
        public static bool Validar(double altura)
        {
            //Altura em cm
            return altura >= 70 && altura < 300;
        }
    }
}
