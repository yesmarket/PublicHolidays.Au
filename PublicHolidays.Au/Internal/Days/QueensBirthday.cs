using System;
using System.Collections.Generic;
using PublicHolidays.Au.Internal.DateOfMonthCalculator;
using PublicHolidays.Au.Internal.Support;

namespace PublicHolidays.Au.Internal.Days
{
    internal sealed class QueensBirthday : IDay
    {
        private readonly IDateOfMonthCalculator _dateOfMonthCalculator;

        public QueensBirthday()
            : this(new DefaultDateOfMonthCalculator())
        {
        }

        public QueensBirthday(IDateOfMonthCalculator dateOfMonthCalculator)
        {
            _dateOfMonthCalculator = dateOfMonthCalculator;
        }

        public State States => State.National;

        /// <summary>
        ///     Second Monday in June.
        /// </summary>
        public IEnumerable<DateTime> GetDatesFor(int year, State state)
        {
            {
                var queensBirthday = new List<DateTime>();

                switch (state)
                {
                    case State.WA:
                    case State.QLD:
                        queensBirthday.Add(_dateOfMonthCalculator.Find(Ordinal.First, DayOfWeek.Monday).In(Month.October).For(year));
                        break;
                    case State.ACT:
                    case State.NSW:
                    case State.NT:
                    case State.SA:
                    case State.TAS:
                    case State.VIC:
                        queensBirthday.Add(_dateOfMonthCalculator.Find(Ordinal.Second, DayOfWeek.Monday).In(Month.June).For(year));
                        break;
                }

                return queensBirthday;
            }
        }
    }
}