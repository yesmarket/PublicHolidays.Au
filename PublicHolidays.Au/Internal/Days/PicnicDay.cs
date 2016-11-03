using System;
using System.Collections.Generic;
using PublicHolidays.Au.Internal.DateOfMonthCalculator;
using PublicHolidays.Au.Internal.Extensions;
using PublicHolidays.Au.Internal.Support;

namespace PublicHolidays.Au.Internal.Days
{
    internal sealed class PicnicDay : IDay
    {
        private readonly IDateOfMonthCalculator _dateOfMonthCalculator;

        public PicnicDay()
            : this(new DefaultDateOfMonthCalculator())
        {
        }

        public PicnicDay(IDateOfMonthCalculator dateOfMonthCalculator)
        {
            _dateOfMonthCalculator = dateOfMonthCalculator;
        }

        public State States => State.NT;
        public bool Regional => false;

        public string GetNameFor(State state)
        {
            return nameof(PicnicDay).ToSentence();
        }

        public IEnumerable<DateTime> GetDatesFor(int year, State state)
        {
            return new List<DateTime>
            {
                _dateOfMonthCalculator.Find(Ordinal.First, DayOfWeek.Monday).In(Month.August).For(year)
            };
        }
    }
}