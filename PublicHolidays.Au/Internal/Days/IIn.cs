using System;
using System.Collections.Generic;

namespace PublicHolidays.Au.Internal.Days
{
    internal interface IIn
    {
        IEnumerable<DateTime> In(int year);
    }
}