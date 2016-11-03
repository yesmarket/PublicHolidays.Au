using System;
using System.Collections.Generic;
using PublicHolidays.Au.Internal.DateOfMonthCalculator;
using PublicHolidays.Au.Internal.Extensions;
using PublicHolidays.Au.Internal.Support;

namespace PublicHolidays.Au.Internal.Days
{
    internal sealed class CanberraDay : IDay
    {
        private readonly IDateOfMonthCalculator _dateOfMonthCalculator;

        public CanberraDay()
            : this(new DefaultDateOfMonthCalculator())
        {
        }

        public CanberraDay(IDateOfMonthCalculator dateOfMonthCalculator)
        {
            _dateOfMonthCalculator = dateOfMonthCalculator;
        }

        public State States => State.ACT;
        public bool Regional => false;

        public string GetNameFor(State state)
        {
            return nameof(CanberraDay).ToSentence();
        }

        public IEnumerable<DateTime> GetDatesFor(int year, State state)
        {
            return new List<DateTime>
            {
                _dateOfMonthCalculator.Find(Ordinal.Third, DayOfWeek.Monday).In(Month.March).For(year)
            };
        }
    }
}