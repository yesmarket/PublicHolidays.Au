using System;
using System.Collections.Generic;

namespace PublicHolidays.Au.Internal.Extensions
{
    internal static class DateTimeExtensions
    {
        public static bool IsWeekend(this DateTime value)
        {
            return value.DayOfWeek.In(DayOfWeek.Saturday, DayOfWeek.Sunday);
        }

        public static IEnumerable<DateTime> Shift(
            this DateTime value,
            Func<DateTime, DateTime> saturday,
            Func<DateTime, DateTime> sunday,
            Func<DateTime, DateTime> monday = null)
        {
            var daysOff = new List<DateTime>();
            switch (value.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                    daysOff.Add(saturday.Invoke(value));
                    break;
                case DayOfWeek.Sunday:
                    daysOff.Add(sunday.Invoke(value));
                    goto default;
                case DayOfWeek.Monday:
                    if (monday != null) daysOff.Add(monday.Invoke(value));
                    goto default;
                default:
                    daysOff.Add(value);
                    break;
            }
            return daysOff;
        }
    }
}