using System;
using System.Collections.Generic;
using PublicHolidays.Au.Internal.Computus;
using PublicHolidays.Au.Internal.Extensions;
using PublicHolidays.Au.Internal.Support;

namespace PublicHolidays.Au.Internal.Days
{
    internal sealed class EasterSaturday : IDay, IIn
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
        public Trait Traits => Trait.AllPostcodes;

        public string GetNameOfPublicHolidayIn(State state)
        {
            return nameof(EasterSaturday).ToSentence();
        }

        public IIn GetPublicHolidayDatesFor(State state)
        {
            return this;
        }

        public IEnumerable<DateTime> In(int year)
        {
            return new[] { _computus.GetCalendarDateOfEasterFor(year).AddDays(-1) };
        }
    }
}