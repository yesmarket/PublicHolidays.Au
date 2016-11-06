using System;
using System.Collections.Generic;
using System.Linq;
using PublicHolidays.Au.Internal.Days;
using PublicHolidays.Au.Internal.Extensions;
using PublicHolidays.Au.Internal.Support;
using AuPublicHolidays = PublicHolidays.Au.Internal.Helpers.PublicHolidays;

namespace PublicHolidays.Au
{
    public sealed class BusinessDaysCalculator : IBusinessDaysCalculator, IStartingFromBusinessDaysCalculator
    {
        private readonly IEnumerable<IDay> _publicHolidays;
        private DateTime _start;
        private State? _state;

        public BusinessDaysCalculator()
            : this(AuPublicHolidays.Get.All)
        {
        }

        internal BusinessDaysCalculator(
            IEnumerable<IDay> publicHolidays)
        {
            _publicHolidays = publicHolidays;
        }

        public IBusinessDaysCalculator In(State state)
        {
            _state = state;
            return this;
        }

        public IStartingFromBusinessDaysCalculator StartingFrom(DateTime startDate)
        {
            _start = startDate;
            return this;
        }

        public DateTime AddBusinessDays(int numberOfDays)
        {
            var state = _state ?? State.National;
            var excludedDates = GetExclusions(numberOfDays, state);

            return GetWorkDays(numberOfDays, excludedDates).Last();
        }

        private List<DateTime> GetExclusions(int days, State state)
        {
            var years = Math.Ceiling(days/365M) + 1;

            var dates = new List<DateTime>();
            for (var i = 0; i < years; i++)
            {
                dates.AddRange(
                    _publicHolidays
                        .Where(_ =>
                            _.States.HasFlag(state) &&
                            !_.Traits.HasFlag(Trait.NotAllPostcodes) &&
                            !_.Traits.HasFlag(Trait.IndustrySpecific))
                        .SelectMany(_ => _.GetPublicHolidayDatesFor(state).In(_start.AddYears(i).Year))
                        .ToList());
            }

            return dates;
        }

        private IEnumerable<DateTime> GetWorkDays(int numberOfDays, ICollection<DateTime> excludedDates)
        {
            var count = 0;
            for (var day = _start.AddDays(1);; day = day.AddDays(1))
            {
                if (!day.IsWeekend() && !day.In(excludedDates.ToArray()))
                {
                    count++;
                    yield return day;
                }

                if (count >= numberOfDays)
                {
                    yield break;
                }
            }
        }
    }
}