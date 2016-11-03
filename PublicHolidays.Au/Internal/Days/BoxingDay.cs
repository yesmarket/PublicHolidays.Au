using System;
using System.Collections.Generic;
using PublicHolidays.Au.Internal.Extensions;

namespace PublicHolidays.Au.Internal.Days
{
    internal sealed class BoxingDay : IDay
    {
        public State States => State.National;
        public bool Regional => false;

        public string GetNameFor(State state)
        {
            return state == State.SA ? "Proclamation Day" : nameof(BoxingDay).ToSentence();
        }

        public IEnumerable<DateTime> GetDatesFor(int year, State state)
        {
            return new DateTime(year, 12, 26).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(2), monday => monday.AddDays(1));
        }
    }
}