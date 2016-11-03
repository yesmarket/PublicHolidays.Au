using System;
using System.Collections.Generic;
using PublicHolidays.Au.Internal.DateOfMonthCalculator;
using PublicHolidays.Au.Internal.Extensions;
using PublicHolidays.Au.Internal.Support;

namespace PublicHolidays.Au.Internal.Days
{
    internal sealed class MelbourneCup : IDay
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
        public bool Regional => true;

        public string GetNameFor(State state)
        {
            return nameof(MelbourneCup).ToSentence();
        }

        public IEnumerable<DateTime> GetDatesFor(int year, State state)
        {
            return new List<DateTime>
            {
                _dateOfMonthCalculator.Find(Ordinal.First, DayOfWeek.Tuesday).In(Month.November).For(year)
            };
        }
    }
}