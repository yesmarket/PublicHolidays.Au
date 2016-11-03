using System;
using System.Collections.Generic;
using PublicHolidays.Au.Internal.Computus;
using PublicHolidays.Au.Internal.Extensions;

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
        public bool Regional => false;

        public string GetNameFor(State state)
        {
            return nameof(EasterMonday).ToSentence();
        }

        public IEnumerable<DateTime> GetDatesFor(int year, State state)
        {
            return new[] { _computus.GetCalendarDateOfEasterFor(year).AddDays(1) };
        }
    }
}