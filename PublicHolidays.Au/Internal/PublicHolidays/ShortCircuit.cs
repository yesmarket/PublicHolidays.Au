using System;
using System.Collections.Generic;

namespace PublicHolidays.Au.Internal.PublicHolidays
{
    public class ShortCircuit : IIn
    {
        public static IIn Response()
        {
            return new ShortCircuit();
        }

        public IEnumerable<DateTime> In(int year)
        {
            return new List<DateTime>();
        }
    }
}