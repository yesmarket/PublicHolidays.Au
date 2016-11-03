using System;
using System.Collections.Generic;
using PublicHolidays.Au.Internal.DateOfMonthCalculator;

namespace PublicHolidays.Au.Internal.Days
{
    internal sealed class FamilyAndCommunityDay : IDay
    {
        private readonly IDateOfMonthCalculator _dateOfMonthCalculator;

        public FamilyAndCommunityDay()
            : this(new DefaultDateOfMonthCalculator())
        {
        }

        public FamilyAndCommunityDay(IDateOfMonthCalculator dateOfMonthCalculator)
        {
            _dateOfMonthCalculator = dateOfMonthCalculator;
        }

        public State States => State.ACT;
        public bool Regional => false;

        public string GetNameFor(State state)
        {
            return "Family & Community Day";
        }

        public IEnumerable<DateTime> GetDatesFor(int year, State state)
        {
            //TODO
            return new List<DateTime>();
        }
    }
}