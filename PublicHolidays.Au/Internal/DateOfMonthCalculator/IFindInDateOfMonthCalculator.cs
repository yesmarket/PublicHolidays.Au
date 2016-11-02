using System;

namespace PublicHolidays.Au.Internal.DateOfMonthCalculator
{
    internal interface IFindInDateOfMonthCalculator
    {
        DateTime For(int year);
    }
}