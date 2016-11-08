using System;

namespace PublicHolidays.Au.Internal.DateOfMonthCalculator
{
    public interface IFindInDateOfMonthCalculator
    {
        DateTime For(int year);
    }
}