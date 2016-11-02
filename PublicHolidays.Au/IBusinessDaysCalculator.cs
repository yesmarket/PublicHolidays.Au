using System;

namespace PublicHolidays.Au
{
    public interface IBusinessDaysCalculator
    {
        IBusinessDaysCalculator In(State state);
        IStartingFromBusinessDaysCalculator StartingFrom(DateTime startDate);
    }
}
