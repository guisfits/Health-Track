using System;

namespace guisfits.HealthTrack.Domain.ValueObjects
{
    public class Nascimento
    {
        public static bool Validar(DateTime nascimento)
        {
            var result = DateTime.Now.Subtract(nascimento);
            return result.TotalDays > 6570; //6570 dias = 18 anos
        }
    }
}
