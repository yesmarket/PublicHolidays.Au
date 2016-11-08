using System;
using System.Collections.Generic;
using PublicHolidays.Au.Internal.Extensions;
using PublicHolidays.Au.Internal.Support;

namespace PublicHolidays.Au.Internal.PublicHolidays
{
    public sealed class GrandFinalEve : IPublicHoliday, IIn
    {
        public State States => State.VIC;
        public Trait Traits => Trait.AllPostcodes;

        public string GetNameOfPublicHolidayIn(State state)
        {
            return nameof(GrandFinalEve).ToSentence();
        }

        public IIn GetPublicHolidayDatesFor(State state)
        {
            return States.HasFlag(state) ? this : ShortCircuit.Response();
        }

        public IEnumerable<DateTime> In(int year)
        {
            // Cannot accurately calculate date of AFL grand final.
            return new List<DateTime>();
        }
    }
}