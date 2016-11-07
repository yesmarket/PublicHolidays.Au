using System;
using System.Collections.Generic;
using PublicHolidays.Au.Internal.Extensions;
using PublicHolidays.Au.Internal.Support;

namespace PublicHolidays.Au.Internal.PublicHolidays
{
    internal sealed class BoxingDay : IPublicHoliday, IIn
    {
        public State States => State.National;
        public Trait Traits => Trait.AllPostcodes;

        public string GetNameOfPublicHolidayIn(State state)
        {
            return state == State.SA ? "Proclamation Day" : nameof(BoxingDay).ToSentence();
        }

        public IIn GetPublicHolidayDatesFor(State state)
        {
            return this;
        }

        public IEnumerable<DateTime> In(int year)
        {
            return new DateTime(year, 12, 26).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(2), monday => monday.AddDays(1));
        }
    }
}