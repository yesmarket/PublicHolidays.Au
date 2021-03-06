using System;
using System.Collections.Generic;
using System.Linq;
using PublicHolidays.Au.Internal.Extensions;
using AuPublicHolidays = PublicHolidays.Au.Internal.Helpers.PublicHolidays;

namespace PublicHolidays.Au
{
    public static class DateTimeExtensions
    {
        public static IEnumerable<KeyValuePair<string, IEnumerable<DateTime>>> GetPublicHolidaysFor(this State state, int year)
        {
            var publicHolidays =
                AuPublicHolidays.Get.All
                    .Where(_ => _.States.HasFlag(state))
                    .Select(_ => new KeyValuePair<string, IEnumerable<DateTime>>(_.GetNameOfPublicHolidayIn(state), _.GetPublicHolidayDatesFor(state).In(year)));
            
            return publicHolidays;
        }

        public static DateTime AddBusinessDays(this DateTime value, int numberOfDays)
        {
            return value.AddBusinessDays(numberOfDays, State.National);
        }

        // ReSharper disable once MemberCanBePrivate.Global
        public static DateTime AddBusinessDays(this DateTime value, int numberOfDays, State state)
        {
            var businessDaysCalculator = new BusinessDaysCalculator();
            var dateTime = businessDaysCalculator.In(state).StartingFrom(value).AddBusinessDays(numberOfDays);

            return dateTime;
        }

        public static bool IsWeekendOrPublicHoliday(this DateTime value)
        {
            return value.IsWeekend() || value.IsPublicHoliday();
        }

        public static bool IsWeekendOrPublicHoliday(this DateTime value, State state)
        {
            return value.IsWeekend() || value.IsPublicHoliday(state);
        }

        public static bool IsPublicHoliday(this DateTime value)
        {
            return IsPublicHoliday(value, State.National);
        }

        public static bool IsPublicHoliday(this DateTime value, State state)
        {
            return GetPublicHolidaysFor(state, value.Year).SelectMany(_ => _.Value).Contains(value);
        }
    }
}