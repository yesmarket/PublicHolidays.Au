using System;
using System.Collections.Generic;
using PublicHolidays.Au.Internal.DateOfMonthCalculator;
using PublicHolidays.Au.Internal.Extensions;
using PublicHolidays.Au.Internal.Support;

namespace PublicHolidays.Au.Internal.Days
{
    internal sealed class MelbourneCup : IDay, IIn
    {
        private readonly IDateOfMonthCalculator _dateOfMonthCalculator;

        public MelbourneCup()
            : this(new DefaultDateOfMonthCalculator())
        {
        }

        public MelbourneCup(IDateOfMonthCalculator dateOfMonthCalculator)
        {
            _dateOfMonthCalculator = dateOfMonthCalculator;
        }

        public State States => State.VIC;
        public Trait Traits => Trait.MostPostcodes;

        public string GetNameOfPublicHolidayIn(State state)
        {
            return nameof(MelbourneCup).ToSentence();
        }

        public IIn GetPublicHolidayDatesFor(State state)
        {
            return this;
        }

        public IEnumerable<DateTime> In(int year)
        {
            return new List<DateTime>
            {
                _dateOfMonthCalculator.Find(Ordinal.First, DayOfWeek.Tuesday).In(Month.November).For(year)
            };
        }
    }
}