using System;
using System.Collections.Generic;
using PublicHolidays.Au.Internal.DateOfMonthCalculator;
using PublicHolidays.Au.Internal.Extensions;
using PublicHolidays.Au.Internal.Support;

namespace PublicHolidays.Au.Internal.Days
{
    internal sealed class BankHoliday : IDay, IIn
    {
        private readonly IDateOfMonthCalculator _dateOfMonthCalculator;

        public BankHoliday()
            : this(new DefaultDateOfMonthCalculator())
        {
        }

        public BankHoliday(IDateOfMonthCalculator dateOfMonthCalculator)
        {
            _dateOfMonthCalculator = dateOfMonthCalculator;
        }

        public State States => State.NSW;
        public Trait Traits => Trait.AllPostcodes | Trait.IndustrySpecific;

        public string GetNameOfPublicHolidayIn(State state)
        {
            return nameof(BankHoliday).ToSentence();
        }

        public IIn GetPublicHolidayDatesFor(State state)
        {
            return this;
        }

        public IEnumerable<DateTime> In(int year)
        {
            return new List<DateTime>
            {
                _dateOfMonthCalculator.Find(Ordinal.First, DayOfWeek.Monday).In(Month.August).For(year)
            };
        }
    }
}
