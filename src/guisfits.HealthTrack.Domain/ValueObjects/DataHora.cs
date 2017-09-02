using System;

namespace guisfits.HealthTrack.Domain.ValueObjects
{
    public class DataHora
    {
        public static bool Validar(DateTime data)
        {
            return data <= DateTime.Now;
        }
    }
}
