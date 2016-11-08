using System;
using System.Collections.Generic;
using System.Linq;
using PublicHolidays.Au.Internal.Extensions;
using PublicHolidays.Au.Internal.Support;

namespace PublicHolidays.Au.Internal.DateOfMonthCalculator
{
    public sealed class DefaultDateOfMonthCalculator : IDateOfMonthCalculator, IFindDateOfMonthCalculator,
        IFindInDateOfMonthCalculator
    {
        private DayOfWeek _dayOfWeek;
        private int _month;
        private int _nth;

        public IFindDateOfMonthCalculator Find(Ordinal nth, DayOfWeek dayOfWeek)
        {
            _dayOfWeek = dayOfWeek;
            _nth = (int) nth;
            return this;
        }

        public IFindInDateOfMonthCalculator In(Month month)
        {
            _month = (int) month;
            return this;
        }

        public DateTime For(int year)
        {
            return
                GetDatesFor(year, _month)
                    .Where(_ => _.DayOfWeek == _dayOfWeek)
                    .Skip(_nth - 1)
                    .First();
        }

        private static IEnumerable<DateTime> GetDatesFor(int year, int month)
        {
            var date = new DateTime(year, month, 1);
            while (date.Month.In(month, month + 1))
            {
                yield return date;
                date = date.AddDays(1);
            }
        }
    }
}