using System;
using System.Collections.Generic;
using PublicHolidays.Au.Internal.DateOfMonthCalculator;
using PublicHolidays.Au.Internal.Extensions;
using PublicHolidays.Au.Internal.Support;

namespace PublicHolidays.Au.Internal.PublicHolidays
{
    internal sealed class QueensBirthday : IPublicHoliday, IIn
    {
        private readonly IDateOfMonthCalculator _dateOfMonthCalculator;
        private State _state;

        public QueensBirthday()
            : this(new DefaultDateOfMonthCalculator())
        {
        }

        public QueensBirthday(IDateOfMonthCalculator dateOfMonthCalculator)
        {
            _dateOfMonthCalculator = dateOfMonthCalculator;
        }

        public State States => State.National;
        public Trait Traits => Trait.MostPostcodes;

        public string GetNameOfPublicHolidayIn(State state)
        {
            return state == State.SA ? "Volunteer's Day" : "Queen's Birthday";
        }

        public IIn GetPublicHolidayDatesFor(State state)
        {
            _state = state;
            return this;
        }

        public IEnumerable<DateTime> In(int year)
        {
            var queensBirthday = new List<DateTime>();

            switch (_state)
            {
                case State.WA:
                    var firstMondayInOctober = _dateOfMonthCalculator.Find(Ordinal.First, DayOfWeek.Monday).In(Month.October).For(year);
                    var lastDayOfSeptember = new DateTime(year, 9, 30);
                    queensBirthday.Add(!lastDayOfSeptember.IsWeekend()
                        ? firstMondayInOctober.AddDays(-7)
                        : firstMondayInOctober);
                    break;
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