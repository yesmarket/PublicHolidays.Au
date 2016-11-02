using System;
using System.Collections.Generic;
using PublicHolidays.Au.Internal.Extensions;

namespace PublicHolidays.Au.Internal.Days
{
    internal sealed class AustraliaDay : IDay
    {
        public State States => State.National;

        /// <summary>
        /// 26 January - if that date falls on a Saturday 
        /// the public holiday transfers to the following 
        /// Monday. If that date falls on a Sunday that 
        /// day and the following Monday will be public 
        /// holidays.
        /// </summary>
        public IEnumerable<DateTime> GetDatesFor(int year, State state)
        {
            return
                new DateTime(year, 1, 26)
                    .Shift(
                        saturday => saturday.AddDays(2),
                        sunday => sunday.AddDays(1));
        }
    }
}