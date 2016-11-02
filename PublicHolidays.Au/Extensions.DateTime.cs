using System;

namespace PublicHolidays.Au
{
    public static class DateTimeExtensions
    {
        public static DateTime AddBusinessDays(this DateTime value, int numberOfDays)
        {
            return value.AddBusinessDays(numberOfDays, State.National);
        }

        // ReSharper disable once MemberCanBePrivate.Global
        public static DateTime AddBusinessDays(this DateTime value, int numberOfDays, State state)
        {
            var businessDaysCalculator = new BusinessDaysCalculator(null);
            var dateTime = businessDaysCalculator.In(state).StartingFrom(value).AddBusinessDays(numberOfDays);

            return dateTime;
        }
    }
}