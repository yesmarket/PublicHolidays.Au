using System;
using System.Collections.Generic;
using PublicHolidays.Au.Internal.Computus;
using PublicHolidays.Au.Internal.Extensions;

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

        public State States => State.ACT | State.NSW | State.NT | State.QLD | State.SA | State.VIC;
        public bool Regional => false;

        public string GetNameFor(State state)
        {
            return nameof(EasterSaturday).ToSentence();
        }

        public IEnumerable<DateTime> GetDatesFor(int year, State state)
        {
            return new[] { _computus.GetCalendarDateOfEasterFor(year).AddDays(-1) };
        }
    }
}