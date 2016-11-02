using System;
using System.Collections.Generic;
using PublicHolidays.Au.Internal.Computus;

namespace PublicHolidays.Au.Internal.Days
{
    internal sealed class EasterMonday : IDay
    {
        private readonly IComputus _computus;

        public EasterMonday()
            : this(new DefaultComputus())
        {
        }

        public EasterMonday(IComputus computus)
        {
            _computus = computus;
        }

        public State States => State.National;

        /// <summary>
        /// Varies according to the lunar cycle.
        /// </summary>
        public IEnumerable<DateTime> GetDatesFor(int year, State state)
        {
            return new[] { _computus.GetCalendarDateOfEasterFor(year).AddDays(1) };
        }
    }
}