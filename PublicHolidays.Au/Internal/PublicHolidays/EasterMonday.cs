using System;
using System.Collections.Generic;
using PublicHolidays.Au.Internal.Computus;
using PublicHolidays.Au.Internal.Extensions;
using PublicHolidays.Au.Internal.Support;

namespace PublicHolidays.Au.Internal.PublicHolidays
{
    public sealed class EasterMonday : IPublicHoliday, IIn
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
        public Trait Traits => Trait.AllPostcodes;

        public string GetNameOfPublicHolidayIn(State state)
        {
            return nameof(EasterMonday).ToSentence();
        }

        public IIn GetPublicHolidayDatesFor(State state)
        {
            return this;
        }

        public IEnumerable<DateTime> In(int year)
        {
            return new[] { _computus.GetCalendarDateOfEasterFor(year).AddDays(1) };
        }
    }
}