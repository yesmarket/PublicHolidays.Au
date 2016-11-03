using System;
using System.Collections.Generic;

namespace PublicHolidays.Au.Internal.Days
{
    internal interface IDay
    {
        State States { get; }
        bool Regional { get; }
        string GetNameFor(State state);
        IEnumerable<DateTime> GetDatesFor(int year, State state);
    }
}