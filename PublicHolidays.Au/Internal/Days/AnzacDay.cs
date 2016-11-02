using System;
using System.Collections.Generic;
using PublicHolidays.Au.Internal.Extensions;

namespace PublicHolidays.Au.Internal.Days
{
    internal sealed class AnzacDay : IDay
    {
        public State States => State.National;

        /// <summary>
        /// 25 April - if the date falls on a Saturday, the 
        /// public holiday is observed on that 
        /// Saturday. If that date falls on a Sunday that 
        /// day and the following Monday will be public 
        /// holidays.
        /// </summary>
        public IEnumerable<DateTime> GetDatesFor(int year, State state)
        {
            return
                new DateTime(year, 4, 25)
                    .Shift(
                        saturday => saturday,
                        sunday => sunday.AddDays(1));
        }
    }
}