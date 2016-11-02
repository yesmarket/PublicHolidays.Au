using System;
using System.Collections.Generic;
using PublicHolidays.Au.Internal.Extensions;

namespace PublicHolidays.Au.Internal.Days
{
    internal sealed class ProclamationDay : IDay
    {
        public State States => State.SA;

        /// <summary>
        /// 26 December - if that date falls on a 
        /// Saturday the public holiday transfers to the 
        /// following Monday. If that date falls on a 
        /// Sunday or a Monday that day and the 
        /// following Tuesday will be public holidays.
        /// </summary>
        public IEnumerable<DateTime> GetDatesFor(int year, State state)
        {
            return
                new DateTime(year, 12, 26)
                    .Shift(
                        saturday => saturday.AddDays(2),
                        sunday => sunday.AddDays(2),
                        monday => monday.AddDays(1));
        }
    }
}