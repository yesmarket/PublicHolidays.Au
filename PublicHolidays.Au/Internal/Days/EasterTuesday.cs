using System;
using System.Collections.Generic;
using PublicHolidays.Au.Internal.Computus;
using PublicHolidays.Au.Internal.Extensions;
using PublicHolidays.Au.Internal.Support;

namespace PublicHolidays.Au.Internal.Days
{
    internal sealed class EasterTuesday : IDay, IIn
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
        public Trait Traits => Trait.AllPostcodes;

        public string GetNameOfPublicHolidayIn(State state)
        {
            return nameof(EasterTuesday).ToSentence();
        }

        public IIn GetPublicHolidayDatesFor(State state)
        {
            return this;
        }

        public IEnumerable<DateTime> In(int year)
        {
            return new[] { _computus.GetCalendarDateOfEasterFor(year).AddDays(2) };
        }
    }
}