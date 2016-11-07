using System;
using System.Collections.Generic;

namespace PublicHolidays.Au.Internal.PublicHolidays
{
    internal interface IIn
    {
        IEnumerable<DateTime> In(int year);
    }
}