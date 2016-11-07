using System;
using System.Collections.Generic;
using PublicHolidays.Au.Internal.Extensions;
using PublicHolidays.Au.Internal.Support;

namespace PublicHolidays.Au.Internal.PublicHolidays
{
    internal sealed class RoyalQueenslandShow  : IPublicHoliday, IIn
    {
        public State States => State.QLD;
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