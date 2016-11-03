using System;
using System.Collections.Generic;
using PublicHolidays.Au.Internal.Extensions;

namespace PublicHolidays.Au.Internal.Days
{
    internal sealed class NewYearsDay : IDay
    {
        public State States => State.National;
        public bool Regional => false;

        public string GetNameFor(State state)
        {
            return nameof(NewYearsDay).ToSentence();
        }

        public IEnumerable<DateTime> GetDatesFor(int year, State state)
        {
            return
                new DateTime(year, 1, 1)
                    .Shift(
                        saturday => saturday.AddDays(2),
                        sunday => sunday.AddDays(1));
        }
    }
}