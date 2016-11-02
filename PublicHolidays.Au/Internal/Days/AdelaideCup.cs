using System;
using System.Collections.Generic;
using PublicHolidays.Au.Internal.DateOfMonthCalculator;
using PublicHolidays.Au.Internal.Support;

namespace PublicHolidays.Au.Internal.Days
{
    internal sealed class AdelaideCup : IDay
    {
        private readonly IDateOfMonthCalculator _dateOfMonthCalculator;

        public AdelaideCup()
            : this(new DefaultDateOfMonthCalculator())
        {
        }

        public AdelaideCup(IDateOfMonthCalculator dateOfMonthCalculator)
        {
            _dateOfMonthCalculator = dateOfMonthCalculator;
        }

        public State States => State.SA;

        /// <summary>
        ///     The Holidays Act 1910 provides for the
        ///     third Monday in May to be a public holiday.
        ///     Since 2006 this public holiday has been
        ///     substituted to the second Monday in March
        ///     through the issuing of a series of
        ///     proclamations by the Governor (currently
        ///     proclaimed until 2019).
        /// </summary>
        public IEnumerable<DateTime> GetDatesFor(int year, State state)
        {
            var daysOff = new List<DateTime>();

            // From the safework.sa.gov.au site, it's not clear what to do after 2019.
            if (year < 2019)
            {
                daysOff.Add(_dateOfMonthCalculator.Find(Ordinal.Third, DayOfWeek.Monday).In(Month.March).For(year));
            }

            return daysOff;
        }
    }
}