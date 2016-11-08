using System;
using System.Collections.Generic;
using PublicHolidays.Au.Internal.DateOfMonthCalculator;
using PublicHolidays.Au.Internal.Extensions;
using PublicHolidays.Au.Internal.Support;

namespace PublicHolidays.Au.Internal.PublicHolidays
{
    public sealed class MarchPublicHoliday : IPublicHoliday, IIn
    {
        private readonly IDateOfMonthCalculator _dateOfMonthCalculator;

        public MarchPublicHoliday()
            : this(new DefaultDateOfMonthCalculator())
        {
        }

        public MarchPublicHoliday(IDateOfMonthCalculator dateOfMonthCalculator)
        {
            _dateOfMonthCalculator = dateOfMonthCalculator;
        }

        public State States => State.SA;
        public Trait Traits => Trait.AllPostcodes;

        public string GetNameOfPublicHolidayIn(State state)
        {
            return nameof(MarchPublicHoliday).ToSentence();
        }

        public IIn GetPublicHolidayDatesFor(State state)
        {
            return States.HasFlag(state) ? this : ShortCircuit.Response();
        }

        public IEnumerable<DateTime> In(int year)
        {
            return year > 2019
                ? new List<DateTime>()
                : new List<DateTime>
                {
                    _dateOfMonthCalculator.Find(Ordinal.Second, DayOfWeek.Monday).In(Month.March).For(year)
                };
        }
    }
}