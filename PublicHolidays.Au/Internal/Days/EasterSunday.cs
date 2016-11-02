using System;
using System.Collections.Generic;
using PublicHolidays.Au.Internal.Computus;

namespace PublicHolidays.Au.Internal.Days
{
    internal sealed class EasterSunday : IDay
    {
        private readonly IComputus _computus;

        public EasterSunday()
            : this(new DefaultComputus())
        {
        }

        public EasterSunday(IComputus computus)
        {
            _computus = computus;
        }

        public State States => State.ACT | State.NSW | State.VIC;

        /// <summary>
        /// Varies according to the lunar cycle.
        /// </summary>
        public IEnumerable<DateTime> GetDatesFor(int year, State state)
        {
            return new[] {_computus.GetCalendarDateOfEasterFor(year)};
        }
    }
}