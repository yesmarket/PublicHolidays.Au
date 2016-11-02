using System.Linq;

namespace PublicHolidays.Au.Internal.Extensions
{
    internal static class GenericExtensions
    {
        public static bool In<T>(this T value, params T[] values)
        {
            return values.Contains(value);
        }
    }
}