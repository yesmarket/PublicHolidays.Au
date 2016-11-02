using System;

namespace PublicHolidays.Au.Internal.Computus
{
    internal sealed class DefaultComputus : IComputus
    {
        /// <summary>
        /// <see href="http://stackoverflow.com/questions/2510383/how-can-i-calculate-what-date-good-friday-falls-on-given-a-year">How can I calculate what date Good Friday falls on, given a value?</see>
        /// </summary>
        public DateTime GetCalendarDateOfEasterFor(int year)
        {
            var g = year % 19;
            var c = year / 100;
            var h = (c - c / 4 - (8 * c + 13) / 25 + 19 * g + 15) % 30;
            var i = h - h / 28 * (1 - h / 28 * (29 / (h + 1)) * ((21 - g) / 11));

            var day = i - (year + year / 4 + i + 2 - c + c / 4) % 7 + 28;
            var month = 3;

            if (day <= 31) return new DateTime(year, month, day);

            month++;
            day -= 31;

            return new DateTime(year, month, day);
        }
    }
}