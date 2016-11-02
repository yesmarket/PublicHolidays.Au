using System;

namespace PublicHolidays.Au.Internal.Computus
{
    internal interface IComputus
    {
        DateTime GetCalendarDateOfEasterFor(int year);
    }
}