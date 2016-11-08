using System;

namespace PublicHolidays.Au.Internal.Computus
{
    public interface IComputus
    {
        DateTime GetCalendarDateOfEasterFor(int year);
    }
}