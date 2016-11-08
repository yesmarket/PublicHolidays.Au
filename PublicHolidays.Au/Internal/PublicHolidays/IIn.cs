using System;
using System.Collections.Generic;

namespace PublicHolidays.Au.Internal.PublicHolidays
{
    public interface IIn
    {
        IEnumerable<DateTime> In(int year);
    }
}