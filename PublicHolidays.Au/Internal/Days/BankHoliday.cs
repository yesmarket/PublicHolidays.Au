using System;
using System.Collections.Generic;
using PublicHolidays.Au.Internal.Extensions;

namespace PublicHolidays.Au.Internal.Days
{
    internal sealed class BankHoliday : IDay
    {
        public State States => State.NSW;
        public bool Regional => true;

        public string GetNameFor(State state)
        {
            return nameof(BankHoliday).ToSentence();
        }

        public IEnumerable<DateTime> GetDatesFor(int year, State state)
        {
            return new List<DateTime>();
        }
    }
}