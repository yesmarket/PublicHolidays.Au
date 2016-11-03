using System;
using System.Collections.Generic;
using PublicHolidays.Au.Internal.DateOfMonthCalculator;
using PublicHolidays.Au.Internal.Extensions;
using PublicHolidays.Au.Internal.Support;

namespace PublicHolidays.Au.Internal.Days
{
    internal sealed class LabourDay : IDay
    {
        private readonly IDateOfMonthCalculator _dateOfMonthCalculator;

        public LabourDay()
            : this(new DefaultDateOfMonthCalculator())
        {
        }

        public LabourDay(IDateOfMonthCalculator dateOfMonthCalculator)
        {
            _dateOfMonthCalculator = dateOfMonthCalculator;
        }

        public State States => State.National;
        public bool Regional => false;

        public string GetNameFor(State state)
        {
            switch (state)
            {
                case State.NT:
                    return "May Day";
                case State.TAS:
                    return "Eight Hours Day";
                default:
                    return nameof(LabourDay).ToSentence();
            }
        }

        public IEnumerable<DateTime> GetDatesFor(int year, State state)
        {
            var labourDay = new List<DateTime>();

            switch (state)
            {
                case State.WA:
                    labourDay.Add(_dateOfMonthCalculator.Find(Ordinal.First, DayOfWeek.Monday).In(Month.March).For(year));
                    break;
                case State.TAS:
                case State.VIC:
                    labourDay.Add(_dateOfMonthCalculator.Find(Ordinal.Second, DayOfWeek.Monday).In(Month.March).For(year));
                    break;
                case State.QLD:
                case State.NT:
                    labourDay.Add(_dateOfMonthCalculator.Find(Ordinal.First, DayOfWeek.Monday).In(Month.May).For(year));
                    break;
                case State.NSW:
                case State.ACT:
                case State.SA:
                    labourDay.Add(_dateOfMonthCalculator.Find(Ordinal.First, DayOfWeek.Monday).In(Month.October).For(year));
                    break;
            }

            return labourDay;
        }
    }
}