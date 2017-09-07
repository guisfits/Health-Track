using System;

namespace guisfits.HealthTrack.Domain.Helpers
{
    public static class StringExtensions
    {
        public static T ParceToEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}
