using System;
using System.Collections.Generic;
using PublicHolidays.Au.Internal.DateOfMonthCalculator;
using PublicHolidays.Au.Internal.Extensions;
using PublicHolidays.Au.Internal.Support;

namespace PublicHolidays.Au.Internal.Days
{
    internal sealed class WesternAustraliaDay : IDay
    {
        private readonly IDateOfMonthCalculator _dateOfMonthCalculator;

        public WesternAustraliaDay()
            : this(new DefaultDateOfMonthCalculator())
        {
        }

        public WesternAustraliaDay(IDateOfMonthCalculator dateOfMonthCalculator)
        {
            _dateOfMonthCalculator = dateOfMonthCalculator;
        }

        public State States => State.WA;
        public bool Regional => false;

        public string GetNameFor(State state)
        {
            return nameof(WesternAustraliaDay).ToSentence();
        }

        public IEnumerable<DateTime> GetDatesFor(int year, State state)
        {
            return new List<DateTime>
            {
                _dateOfMonthCalculator.Find(Ordinal.First, DayOfWeek.Monday).In(Month.June).For(year)
            };
        }
    }
}