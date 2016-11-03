using System;
using System.Collections.Generic;
using PublicHolidays.Au.Internal.DateOfMonthCalculator;
using PublicHolidays.Au.Internal.Extensions;

namespace PublicHolidays.Au.Internal.Days
{
    internal sealed class GrandFinalEve : IDay
    {
        private readonly IDateOfMonthCalculator _dateOfMonthCalculator;

        public GrandFinalEve()
            : this(new DefaultDateOfMonthCalculator())
        {
        }

        public GrandFinalEve(IDateOfMonthCalculator dateOfMonthCalculator)
        {
            _dateOfMonthCalculator = dateOfMonthCalculator;
        }

        public State States => State.VIC;
        public bool Regional => false;

        public string GetNameFor(State state)
        {
            return nameof(GrandFinalEve).ToSentence();
        }

        public IEnumerable<DateTime> GetDatesFor(int year, State state)
        {
            //TODO
            return new List<DateTime>();
        }
    }
}