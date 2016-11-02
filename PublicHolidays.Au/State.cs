using System;

namespace PublicHolidays.Au
{
    [Flags]
    public enum State
    {
        ACT = 1,
        NSW = 2,
        NT = 4,
        QLD = 8,
        SA = 16,
        TAS = 32,
        VIC = 64,
        WA = 128,
        National = ACT | NSW | NT | QLD | SA | TAS | VIC | WA
    }
}