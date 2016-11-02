using System;
using PublicHolidays.Au.Internal.Support;

namespace PublicHolidays.Au.Internal.DateOfMonthCalculator
{
    internal interface IDateOfMonthCalculator
    {
        IFindDateOfMonthCalculator Find(Ordinal nth, DayOfWeek dayOfWeek);
    }
}