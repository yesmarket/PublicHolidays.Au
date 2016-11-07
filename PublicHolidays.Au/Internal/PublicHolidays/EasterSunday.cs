using System;
using System.Collections.Generic;
using PublicHolidays.Au.Internal.Computus;
using PublicHolidays.Au.Internal.Extensions;
using PublicHolidays.Au.Internal.Support;

namespace PublicHolidays.Au.Internal.PublicHolidays
{
    internal sealed class EasterSunday : IPublicHoliday, IIn
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
        public Trait Traits => Trait.AllPostcodes;

        public string GetNameOfPublicHolidayIn(State state)
        {
            return nameof(EasterSunday).ToSentence();
        }

        public IIn GetPublicHolidayDatesFor(State state)
        {
            return this;
        }

        public IEnumerable<DateTime> In(int year)
        {
            return new[] {_computus.GetCalendarDateOfEasterFor(year)};
        }
    }
}