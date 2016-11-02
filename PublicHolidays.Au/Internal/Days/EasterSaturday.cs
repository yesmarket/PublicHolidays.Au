using System;
using System.Collections.Generic;
using PublicHolidays.Au.Internal.Computus;

namespace PublicHolidays.Au.Internal.Days
{
    internal sealed class EasterSaturday : IDay
    {
        private readonly IComputus _computus;

        public EasterSaturday()
            : this(new DefaultComputus())
        {
        }

        public EasterSaturday(IComputus computus)
        {
            _computus = computus;
        }

        public State States => State.ACT | State.NSW | State.NT | State.QLD | State.SA | State.TAS | State.VIC | State.WA;

        /// <summary>
        /// Varies according to the lunar cycle.
        /// </summary>
        public IEnumerable<DateTime> GetDatesFor(int year, State state)
        {
            return new[] { _computus.GetCalendarDateOfEasterFor(year).AddDays(-1) };
        }
    }
}