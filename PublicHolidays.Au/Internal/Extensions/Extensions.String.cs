using System.Text.RegularExpressions;

namespace PublicHolidays.Au.Internal.Extensions
{
    internal static class StringExtensions
    {
        public static string ToSentence(this string str)
        {
            return Regex.Replace(str, "[a-z][A-Z]", m => $"{m.Value[0]} {char.ToLower(m.Value[1])}");
        }
    }
}