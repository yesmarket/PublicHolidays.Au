using System.Globalization;
using System.Text.RegularExpressions;

namespace PublicHolidays.Au.Internal.Extensions
{
    internal static class StringExtensions
    {
        public static string ToSentence(this string str)
        {
            var sentence = Regex.Replace(str, "[a-z][A-Z]", m => $"{m.Value[0]} {char.ToLower(m.Value[1])}");
            var titleCase = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(sentence.ToLower());

            return titleCase;

        }
    }
}