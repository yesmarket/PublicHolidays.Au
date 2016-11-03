using System;
using System.Collections.Generic;
using PublicHolidays.Au.Internal.Extensions;

namespace PublicHolidays.Au.Internal.Days
{
    internal sealed class RoyalQueenslandShow : IDay
    {
        public State States => State.QLD;
        public bool Regional => true;

        public string GetNameFor(State state)
        {
            return nameof(RoyalQueenslandShow).ToSentence();
        }

        public IEnumerable<DateTime> GetDatesFor(int year, State state)
        {
            return new List<DateTime>();
        }
    }
}