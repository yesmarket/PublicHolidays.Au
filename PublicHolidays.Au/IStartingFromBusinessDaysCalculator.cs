using System;

namespace PublicHolidays.Au
{
    public interface IStartingFromBusinessDaysCalculator
    {
        DateTime AddBusinessDays(int numberOfDays);
    }
}