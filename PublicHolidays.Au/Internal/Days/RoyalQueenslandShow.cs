using System;
using System.Collections.Generic;
using PublicHolidays.Au.Internal.Extensions;
using PublicHolidays.Au.Internal.Support;

namespace PublicHolidays.Au.Internal.Days
{
    internal sealed class RoyalQueenslandShow  : IDay, IIn
    {
        public State States => State.NSW;
        public Trait Traits => Trait.NotAllPostcodes;

        public string GetNameOfPublicHolidayIn(State state)
        {
            return nameof(RoyalQueenslandShow).ToSentence();
        }

        public IIn GetPublicHolidayDatesFor(State state)
        {
            return this;
        }

        public IEnumerable<DateTime> In(int year)
        {
            return new List<DateTime>();
        }
    }
}