using System.Text.RegularExpressions;

namespace guisfits.HealthTrack.Domain.ValueObjects
{
    public class NomeSobrenome
    {
        public static bool Validar(string nome)
        {
            return Regex.IsMatch(nome, "^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$", RegexOptions.IgnorePatternWhitespace);
        }
    }
}
