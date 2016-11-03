using System;
using System.Collections.Generic;
using PublicHolidays.Au.Internal.Computus;
using PublicHolidays.Au.Internal.Extensions;

namespace PublicHolidays.Au.Internal.Days
{
    internal sealed class EasterTuesday : IDay
    {
        private readonly IComputus _computus;

        public EasterTuesday()
            : this(new DefaultComputus())
        {
        }

        public EasterTuesday(IComputus computus)
        {
            _computus = computus;
        }

        public State States => State.TAS;
        public bool Regional => false;

        public string GetNameFor(State state)
        {
            return nameof(EasterTuesday).ToSentence();
        }

        public IEnumerable<DateTime> GetDatesFor(int year, State state)
        {
            return new[] { _computus.GetCalendarDateOfEasterFor(year).AddDays(2) };
        }
    }
}