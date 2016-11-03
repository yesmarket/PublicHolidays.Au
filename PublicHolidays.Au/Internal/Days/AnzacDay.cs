using System;
using System.Collections.Generic;
using PublicHolidays.Au.Internal.Extensions;

namespace PublicHolidays.Au.Internal.Days
{
    internal sealed class AnzacDay : IDay
    {
        public State States => State.National;
        public bool Regional => false;

        public string GetNameFor(State state)
        {
            return nameof(AnzacDay).ToSentence();
        }

        public IEnumerable<DateTime> GetDatesFor(int year, State state)
        {
            return
                new DateTime(year, 4, 25)
                    .Shift(
                        saturday => saturday,
                        sunday => sunday.AddDays(1));
        }
    }
}